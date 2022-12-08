using WayToDev.Domain.Entities;

namespace WayToDev.Domain.Interfaces.DAOs;

public interface INewsDao
{
    Task Create(News news);
    Task Update(News news);
    Task Delete(Guid id);
}