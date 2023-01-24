using AutoMapper;
using WayToDev.Client.ViewModels;
using WayToDev.Core.DTOs;
using WayToDev.Core.Entities;

namespace WayToDev.Client.Mapping;

public class NewsMapperProfile : Profile
{
    public NewsMapperProfile()
    {
        CreateMap<News, NewsDto>()
            .ForMember(x=>x.Image, opts=>opts.MapFrom(src=>src.Image!.ImageUrl));
        CreateMap<NewsDto, News>()
            .ForMember(dest=>dest.Image, opts => opts.MapFrom(src=>new Image(src.Image)));
        CreateMap<NewsViewModel, NewsDto>();
        CreateMap<NewsDto, NewsViewModel>();
    }
}