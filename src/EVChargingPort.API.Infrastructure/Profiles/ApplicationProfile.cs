using System.Text.Json;
using AutoMapper;
using EVChargingPort.API.Domain.Models;

namespace EVChargingPort.API.Infrastructure.Profiles;

public class ApplicationProfile : Profile
{
    public ApplicationProfile()
    {
        CreateMap<UserApplication, Entities.Application>()
            .ForMember(dest => dest.Address,
                opt => opt.MapFrom(src => JsonSerializer.Serialize(src.Address, new JsonSerializerOptions())));
    }
}