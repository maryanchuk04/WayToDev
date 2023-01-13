using AutoMapper;
using WayToDev.Core.DTOs;
using WayToDev.Core.Entities;

namespace WayToDev.Client.Mapping;

public class MessageMapperProfile : Profile
{
    public MessageMapperProfile()
    {
        CreateMap<Message, MessageDto>();
    }
}