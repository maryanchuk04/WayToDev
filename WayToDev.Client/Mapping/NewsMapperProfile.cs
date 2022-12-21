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
        CreateMap<NewsDto, News>()
            .ForMember(dest=>dest.Image, opts => opts.MapFrom(src=>src.Image));
        CreateMap<NewsViewModel, NewsDto>();
        CreateMap<NewsDto, NewsViewModel>();
        CreateMap<string, Image>()
            .ForMember(dest => dest.ImageUrl, opts => opts.MapFrom(x => x));
    }
}