using AutoMapper;
using WayToDev.Client.ViewModels;
using WayToDev.Core.DTOs;
using WayToDev.Core.Entities;

namespace WayToDev.Client.Mapping;

public class CompanyMapperProfile : Profile
{
    public CompanyMapperProfile()
    {
        CreateMap<Company, CompanyDto>()
            .ForMember(dest=>dest.Email, opts=>opts.MapFrom(x=>x.Account.Email))
            .ForMember(dest=> dest.Tags, opts => opts.MapFrom(src => MapTechnologies(src.TechStack.ToList())))
            .ForMember(dest=>dest.ImageUrl, opts => opts.MapFrom(src => src.Image!.ImageUrl));
        CreateMap<CompanyViewModel, CompanyDto>();
    }
    
    private static List<TagDto> MapTechnologies(List<TechStack> techStacks)
    {
        var tags = techStacks.Select(x => x.Tag);
        return new List<TagDto>(tags.Select(x => new TagDto
        {
            ImageUrl = x.Image.ImageUrl,
            TagName = x.TagName,
            Id = x.Id
        }));
    }
}