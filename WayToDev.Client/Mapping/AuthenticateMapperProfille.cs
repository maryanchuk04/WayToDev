using AutoMapper;
using WayToDev.Client.ViewModels;
using WayToDev.Core.DTOs;

namespace WayToDev.Client.Mapping;

public class AuthenticateMapperProfile : Profile
{
    public AuthenticateMapperProfile()
    {
        CreateMap<RegistrViewModel, RegistrDto>();
    }
}