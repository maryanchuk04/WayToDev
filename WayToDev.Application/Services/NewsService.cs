using AutoMapper;
using WayToDev.Domain.DTOs;
using WayToDev.Domain.Entities;
using WayToDev.Domain.Interfaces.DAOs;
using WayToDev.Domain.Interfaces.Services;

namespace WayToDev.Application.Services;

public class NewsService : INewsService
{
    private readonly INewsDao _newsDao;
    private readonly IMapper _mapper;
    
    public NewsService(INewsDao newsDao, IMapper mapper)
    {
        _newsDao = newsDao;
        _mapper = mapper;
    }
    
    public async Task Create(NewsDto newsDto)
    {
        await _newsDao.Create(_mapper.Map<NewsDto, News>(newsDto));
    }

    public async Task Update(NewsDto newsDto)
    {
        if (newsDto == null)
        {
            throw new ArgumentException("NewsDto is null");
        }
        await _newsDao.Update(_mapper.Map<NewsDto, News>(newsDto));
    }

    public NewsDto GetNewsById(Guid id)
    {
        return _mapper.Map<News, NewsDto>(_newsDao.GetById(id));
    }

    public List<NewsDto> GetNews()
    {
        return _mapper.Map<List<News>, List<NewsDto>>(_newsDao.GetNews());
    }
}