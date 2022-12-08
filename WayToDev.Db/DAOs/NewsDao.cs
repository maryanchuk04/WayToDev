using AutoMapper;
using WayToDev.Application.Exceptions;
using WayToDev.Db.Daos.Base;
using WayToDev.Domain.Entities;
using WayToDev.Domain.Interfaces.DAOs;

namespace WayToDev.Db.Daos;

public class NewsDao : Dao<News>,INewsDao
{
    public NewsDao(ApplicationContext context, IMapper mapper = null) : base(context, mapper)
    {
    }
    
    public async Task Create(News news)
    {
        Insert(news);
        await Context.SaveChangesAsync();
    }

    public new async Task Update(News news)
    {
        base.Update(news);
        await Context.SaveChangesAsync();
    }

    public async Task Delete(Guid id)
    {
        var news = Context.NewsSet.FirstOrDefault(x => x.Id == id);
        if (news == null)
        {
            throw new NewsNotFoundException("News with this id is not exist");
        }
        base.Delete(news);
        await Context.SaveChangesAsync();
    }

}