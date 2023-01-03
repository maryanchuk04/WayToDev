using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WayToDev.Core.DTOs;
using WayToDev.Core.Entities;
using WayToDev.Core.Enums;
using WayToDev.Core.Exceptions;
using WayToDev.Core.Interfaces.Services;
using WayToDev.Db.EF;

namespace WayToDev.Application.Services;

public class UserService : Dao<User>, IUserService
{
    private readonly ISecurityContext _securityContext;
    public UserService(ApplicationContext context, ISecurityContext securityContext, IMapper mapper = null) : base(context, mapper)
    {
        _securityContext = securityContext;
    }


    public UserDto GetCurrentUserInfo()
    {
        var userId = _securityContext.GetCurrentUserId();
        var user = Context.Users
            .Include(x => x.Account)
            .Include(x => x.Image)
            .Include(x=>x.TechStack)
                .ThenInclude(x=>x.Tag)
                    .ThenInclude(x=>x.Image)
            .FirstOrDefault(x=>x.Id == userId);

        if (user == null)
            throw new UserNotFoundException("User with this id is not found!");
        
        return Mapper.Map<User, UserDto>(user);
    }

    public async Task AddTechnologyTags(List<Guid> tagsIds)
    {
        var user = GetCurrentUser();
        var tags = 
            (from tagId in tagsIds
            where Context.Tags.Any(x => x.Id == tagId)
            select Context.Tags.First(x => x.Id == tagId)).ToList();

        foreach (var tag in tags)
        {
            user.TechStack.Add(new TechStack
            {
                Tag = tag,
                User = user,
            });
        }

        Update(user);
        await Context.SaveChangesAsync();
    }

    public async Task UpdateUserInfo(
        string userName, 
        string firstName, 
        string lastName, 
        DateTime birthday, 
        string imageUrl, 
        Gender gender,
        List<TagDto>tagDtos
        )
    {
        var user = GetCurrentUser();
        user.UserName = userName;
        user.FirstName = firstName;
        user.LastName = lastName;
        user.Birthday = birthday;
        user.Gender = gender;
        if (user.Image == null)
        {
            user.Image = new Image(imageUrl);
        }
        else
            user.Image.ImageUrl = imageUrl;
        
        if(TechStackIsUpdated(tagDtos, user.TechStack.ToList()))
            UpdateUserTechnologies(tagDtos.Select(x=>x.Id), user);
        
        Update(user);
        await Context.SaveChangesAsync();
    }

    public void UpdateUserTechnologies(IEnumerable<Guid> technologiesIds, User user)
    {
        var techList = technologiesIds.Select(id => Context.Tags.First(x => x.Id == id)).ToList();
        foreach (var tag in techList)
        {
            user.TechStack.Add(new TechStack
            {
                Tag = tag,
                User = user
            });
        }
    }

    private User GetCurrentUser() => Context.Users
                                         .Include(x=>x.Image)
                                         .Include(x=>x.TechStack)
                                            .ThenInclude(x=>x.Tag)
                                         .FirstOrDefault(x => x.Id ==  _securityContext.GetCurrentUserId())
                                     ?? throw new UserNotFoundException("User Not Found");

    private bool TechStackIsUpdated(List<TagDto> incomingTags, List<TechStack> userTags)
    {
        var incomingTagsIds = incomingTags.Select(x => x.Id).ToList();
        var userTagsIds = userTags.Select(x => x.Tag.Id).ToList();
        return !incomingTagsIds.SequenceEqual(userTagsIds);
    }
}