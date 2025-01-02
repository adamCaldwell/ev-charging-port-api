using AutoMapper;
using EVChargingPort.API.Domain.Models;

namespace EVChargingPort.API.Infrastructure.Profiles;

public class ApplicationProfile : Profile
{
    public ApplicationProfile()
    {
        CreateMap<UserApplication, Entities.Application>();
    }
}