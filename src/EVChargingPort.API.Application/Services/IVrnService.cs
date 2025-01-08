using EVChargingPort.API.Domain.Models;

namespace EVChargingPort.API.Application.Services;

public interface IVrnService
{
    Eligibility CheckEligibility(string vrn);
}
