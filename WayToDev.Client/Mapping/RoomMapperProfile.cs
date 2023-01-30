using AutoMapper;
using WayToDev.Core.DTOs;
using WayToDev.Core.Entities;

namespace WayToDev.Client.Mapping;

public class RoomMapperProfile : Profile
{
    public RoomMapperProfile()
    {
        CreateMap<Room, RoomPreviewDto>()
            .ForMember(x=>x.LastMessage, opts => opts.MapFrom(x=>x.Messages.Last()));
    }
}