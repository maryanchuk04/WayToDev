using AutoMapper;
using WayToDev.Core.DTOs;
using WayToDev.Core.Entities;

namespace WayToDev.Client.Mapping;

public class UserMapperProfile : Profile
{
    public UserMapperProfile()
    {
        CreateMap<User, UserDto>();
    }
}