using WayToDev.Core.DTOs;

namespace WayToDev.Core.Interfaces.Services;

public interface INewsService
{
    Task Create(NewsDto newsDto);
    Task Update(NewsDto newsDto);
    NewsDto GetNewsById(Guid id);
    List<NewsDto> GetNews();
}