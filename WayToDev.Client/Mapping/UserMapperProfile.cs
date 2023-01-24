using AutoMapper;
using WayToDev.Core.DTOs;
using WayToDev.Core.Entities;

namespace WayToDev.Client.Mapping;

public class UserMapperProfile : Profile
{
    public UserMapperProfile()
    {
        CreateMap<UserDto, User>();
        CreateMap<User, UserDto>()
            .ForMember(dest => dest.ImageUrl, opts => opts.MapFrom(x => x.Image!.ImageUrl))
            .ForMember(dest=> dest.Tags, opts => opts.MapFrom(src => MapTechnologies(src.TechStack.ToList())));
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