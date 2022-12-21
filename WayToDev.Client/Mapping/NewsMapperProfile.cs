using AutoMapper;
using WayToDev.Client.ViewModels;
using WayToDev.Core.DTOs;
using WayToDev.Core.Entities;

namespace WayToDev.Client.Mapping;

public class NewsMapperProfile : Profile
{
    public NewsMapperProfile()
    {
        CreateMap<News, NewsDto>();
        CreateMap<NewsDto, News>();
        CreateMap<NewsViewModel, NewsDto>();
        CreateMap<NewsDto, NewsViewModel>();
    }
}