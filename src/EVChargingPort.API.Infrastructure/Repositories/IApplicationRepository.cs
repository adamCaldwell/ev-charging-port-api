using EVChargingPort.API.Domain.Models;
using EVChargingPort.API.Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EVChargingPort.API.Infrastructure.Repositories;

public interface IApplicationRepository
{
    Task AddApplicationAsync(UserApplication application);
}