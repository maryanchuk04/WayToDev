using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WayToDev.Core.DTOs;
using WayToDev.Core.Entities;
using WayToDev.Core.Exceptions;
using WayToDev.Core.Interfaces.Services;
using WayToDev.Db.EF;

namespace WayToDev.Application.Services;

public class TagService : Dao<Tag>, ITagService
{
    public TagService(ApplicationContext context, IMapper mapper = null) : base(context, mapper)
    {
    }

    public async Task<TagDto> InsertNewTag(string tagName, string tagImage)
    {
        var tag = Insert(new Tag
        {
            Image = new Image(tagImage),
            TagName = tagName
        });

        await Context.SaveChangesAsync();
        return Mapper.Map<Tag, TagDto>(tag);
    }

    public async Task DeleteTag(Guid id)
    {
        var tag = Context.Tags
            .Include(x => x.Image)
            .FirstOrDefault(x=>x.Id == id);

        if (tag == null)
            throw new TagExceptions("Tag not found exception");
        
        Delete(tag);
        await Context.SaveChangesAsync();
    }

    public async Task<List<TagDto>> GetAllTags() 
    {
       var result = await Context.Tags
            .Include(x => x.Image).ToListAsync();
       return Mapper.Map<List<Tag>, List<TagDto>>(result);
    }

    public List<TagDto> FilteredTags(Func<Tag, bool> condition)
    {
        var result = Context.Tags
            .Include(x => x.Image)
            .Where(condition).ToList();
        return Mapper.Map<List<Tag>, List<TagDto>>(result);
    }

    public async Task<TagDto> UpdateTag(Guid id, string tagName, string imageUrl)
    {
        var tag = Context.Tags
            .Include(x => x.Image)
            .FirstOrDefault(x => x.Id == id);
        if (tag == null)
            throw new TagExceptions("Tag not found");

        tag.TagName = tagName;
        tag.Image.ImageUrl = imageUrl;

        Update(tag);
        await Context.SaveChangesAsync();
        return Mapper.Map<Tag, TagDto>(tag);
    }
}