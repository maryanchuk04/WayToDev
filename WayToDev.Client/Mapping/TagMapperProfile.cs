using AutoMapper;
using WayToDev.Client.ViewModels;
using WayToDev.Core.DTOs;
using WayToDev.Core.Entities;

namespace WayToDev.Client.Mapping;

public class TagMapperProfile : Profile
{
    public TagMapperProfile()
    {
        CreateMap<Tag, TagDto>()
            .ForMember(dest => dest.ImageUrl, opts=>opts.MapFrom(x=>x.Image.ImageUrl));
        CreateMap<TagViewModel, TagDto>();
    }
}