using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WayToDev.Core.Exceptions;
using WayToDev.Core.Interfaces.DAOs.Base;
using WayToDev.Db.EF;

namespace WayToDev.Application.Services;

public class Dao<T> : IDao<T>
    where T : class
{
    public Dao(ApplicationContext context, IMapper mapper = null)
    {
        Context = context;
        Mapper = mapper;
    }

    protected ApplicationContext Context { get; set; }

    protected DbSet<T> Entities => Context.Set<T>();

    protected IMapper Mapper { get; set; }


    public T Insert(T entity)
    {
        if (entity == null)
        {
            throw new DataAccessException("Entity not inserted");
        }

        Entities.Add(entity);
        return entity;
    }

    public T Update(T entity)
    {
        if (entity == null)
        {
            throw new DataAccessException("Entity not Updated");
        }

        Entities.Update(entity);
        return entity;
    }

    public T Delete(T entity)
    {
        if (entity == null)
        {
            throw new DataAccessException("Entity not deleted");
        }

        Entities.Remove(entity);
        return entity;
    }
}