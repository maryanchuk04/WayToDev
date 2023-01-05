using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WayToDev.Core.DTOs;
using WayToDev.Core.Entities;
using WayToDev.Core.Exceptions;
using WayToDev.Core.Interfaces.Services;
using WayToDev.Db.EF;

namespace WayToDev.Application.Services;

public class NewsService : Dao<News>, INewsService
{
    public NewsService(ApplicationContext context, IMapper mapper = null) : base(context, mapper)
    {
    }
    
    public async Task<NewsDto> Create(NewsDto newsDto)
    {
        var news = Insert(Mapper.Map<NewsDto, News>(newsDto));
        await Context.SaveChangesAsync();
        return Mapper.Map<News, NewsDto>(news);
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
        var news = Context.NewsSet
            .Include(x=>x.Image)
            .FirstOrDefault(x => x.Id == id);
        if (news == null)
        {
            throw new NewsNotFoundException("News with this id is not exist");
        }

        return Mapper.Map<News, NewsDto>(news);
    }

    public List<NewsDto> GetNews() => Mapper.Map<List<News>, List<NewsDto>>(Context.NewsSet.ToList());
    public async Task Delete(Guid id)
    {
        var news = Context.NewsSet.FirstOrDefault(x => x.Id == id);
        base.Delete(news);
        
        await Context.SaveChangesAsync();
    }

    public IEnumerable<NewsDto> GetFilteredNews(NewsFilterViewModel model, out int count)
    {
        var news = Context.NewsSet
            .Include(x => x.Image)
            .OrderByDescending(x=>x.Date.Date)
            .ThenByDescending(x=>x.Date.TimeOfDay)
            .AsNoTracking();
        
        news = !string.IsNullOrEmpty(model.SearchWord)
            ? news.Where(x => x.Title.Contains(model.SearchWord) || x.Text.Contains(model.SearchWord))
            : news;

        count = news.Count();
        var newsList = news.Skip((model.Page - 1) * model.PageSize)
            .Take(model.PageSize)
            .ToList();

       
        return Mapper.Map<IEnumerable<NewsDto>>(newsList);
    }
}