using EVChargingPort.API.Domain.Models;

namespace EVChargingPort.API.Application.Services;

public interface IApplicationService
{
    Task Submit(UserApplication application);
}
