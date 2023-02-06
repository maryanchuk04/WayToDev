using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WayToDev.Core.DTOs;
using WayToDev.Core.Entities;
using WayToDev.Core.Exceptions;
using WayToDev.Core.Interfaces.Services;
using WayToDev.Db.EF;

namespace WayToDev.Application.Services;

public class UsersService : Dao<User>, IUsersService
{
    public UsersService(ApplicationContext context, IMapper mapper = null) : base(context, mapper)
    {
    }

    public async Task<List<UserDto>> GetUsers()
    {
        return Mapper.Map<List<User>, List<UserDto>>(await Context.Users.ToListAsync());
    }

    public async Task<UserDto> GetUserByIdAsync(Guid id)
    {
        var user = await Context.Users
            .Include(x => x.TechStack)
            .ThenInclude(x => x.Tag)
            .ThenInclude(x => x.Image)
            .Include(x => x.Image)
            .Include(x => x.Account)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (user == null)
            throw new UserNotFoundException("User not found");

        return Mapper.Map<User, UserDto>(user);
    }

    public List<UserDto> GetFilteredUsers(FilterViewModel filterViewModel, out int count)
    {
        var usersQueryable = Context.Users
            .Include(x => x.Image)
            .Include(x => x.Account)
            .Include(x => x.TechStack)
                .ThenInclude(x => x.Tag)
            .AsNoTracking();
        
        usersQueryable = !string.IsNullOrEmpty(filterViewModel.SearchWord)
            ? usersQueryable.Where(x => x.FirstName.Contains(filterViewModel.SearchWord) 
                                        || x.LastName!.Contains(filterViewModel.SearchWord)
                                        || x.UserName.Contains(filterViewModel.SearchWord))
            : usersQueryable;
        
        count = usersQueryable.Count();
        var users = usersQueryable.Skip((filterViewModel.Page - 1) * filterViewModel.PageSize)
            .Take(filterViewModel.PageSize)
            .ToList();

        return Mapper.Map<List<User>, List<UserDto>>(users);
    }
}