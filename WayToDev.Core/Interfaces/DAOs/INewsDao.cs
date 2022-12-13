using WayToDev.Core.Entities;

namespace WayToDev.Core.Interfaces.DAOs;

public interface INewsDao
{
    Task Create(News news);
    Task Update(News news);
    Task Delete(Guid id);
    News GetById(Guid id);
    List<News> GetNews();
}