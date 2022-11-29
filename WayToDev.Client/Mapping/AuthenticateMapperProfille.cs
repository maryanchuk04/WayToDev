using AutoMapper;
using WayToDev.Client.ViewModels;
using WayToDev.Domain.DTOs;

namespace WayToDev.Client.Mapping;

public class AuthenticateMapperProfile : Profile
{
    public AuthenticateMapperProfile()
    {
        CreateMap<RegistrViewModel, RegistrDto>();
    }
}