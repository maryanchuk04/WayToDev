using WayToDev.Core.DTOs;
using WayToDev.Core.Entities;

namespace WayToDev.Core.Interfaces.Services;

public interface ITagService
{
    Task<TagDto> InsertNewTag(string tagName, string tagImage);
    Task DeleteTag(Guid id);
    Task<List<TagDto>> GetAllTags();
    List<TagDto> FilteredTags(Func<Tag, bool> condition);
    Task<TagDto> UpdateTag(Guid id, string tagName, string imageUrl);
}