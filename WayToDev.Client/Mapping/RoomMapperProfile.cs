using AutoMapper;
using WayToDev.Core.DTOs;
using WayToDev.Core.Entities;

namespace WayToDev.Client.Mapping;

public class RoomMapperProfile : Profile
{
    public RoomMapperProfile()
    {
        CreateMap<Room, RoomPreviewDto>()
            .ForMember(x=>x.User, opts => opts.MapFrom(x=>x.UserRooms.First().User))
            .ForMember(x=>x.LastMessage, opts => opts.MapFrom(x=>x.Messages.LastOrDefault()));

        CreateMap<Room, RoomDto>()
            .ForMember(x=>x.Users, opts => opts.MapFrom(x=>x.UserRooms.Select(u=>u.User)));
    }
}