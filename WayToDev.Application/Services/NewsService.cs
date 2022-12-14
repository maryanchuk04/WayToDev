using AutoMapper;
using WayToDev.Core.DTOs;
using WayToDev.Core.Entities;
using WayToDev.Core.Exceptions;
using WayToDev.Core.Interfaces.DAOs;
using WayToDev.Core.Interfaces.Services;
using WayToDev.Db.EF;

namespace WayToDev.Application.Services;

public class NewsService : Dao<News>, INewsService
{
    public NewsService(ApplicationContext context, IMapper mapper = null) : base(context, mapper)
    {
    }
    
    public async Task Create(NewsDto newsDto)
    {
        Insert(Mapper.Map<NewsDto, News>(newsDto));
        await Context.SaveChangesAsync();
    }

    public async Task Update(NewsDto newsDto)
    {
        if (newsDto == null)
        {
            throw new ArgumentException("NewsDto is null");
        }

        Update(Mapper.Map<NewsDto, News>(newsDto));
        await Context.SaveChangesAsync();
    }

    public NewsDto GetNewsById(Guid id)
    {
        var news = Context.NewsSet.FirstOrDefault(x => x.Id == id);
        if (news == null)
        {
            throw new NewsNotFoundException("News with this id is not exist");
        }

        return Mapper.Map<News, NewsDto>(news);
    }

    public List<NewsDto> GetNews() => Mapper.Map<List<News>, List<NewsDto>>(Context.NewsSet.ToList());
    
}