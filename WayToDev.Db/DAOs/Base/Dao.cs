using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WayToDev.Domain.Interfaces.DAOs.Base;

namespace WayToDev.Db.Daos.Base;

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
            throw new NotImplementedException();
        }

        Entities.Add(entity);
        return entity;
    }

    public T Update(T entity)
    {
        if (entity == null)
        {
            throw new NotImplementedException();
        }

        Entities.Update(entity);
        return entity;
    }

    public T Delete(T entity)
    {
        if (entity == null)
        {
            throw new NotImplementedException();
        }

        Entities.Remove(entity);
        return entity;
    }
}