using AutoMapper;
using WayToDev.Core.DTOs;
using WayToDev.Core.Entities;

namespace WayToDev.Client.Mapping;

public class CompanyMapperProfile : Profile
{
    public CompanyMapperProfile()
    {
        CreateMap<Company, CompanyDto>()
            .ForMember(dest=>dest.ImageUrl, opts => opts.MapFrom(src => src.Image!.ImageUrl));
        
    }
}