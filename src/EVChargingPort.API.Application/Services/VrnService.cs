using EVChargingPort.API.Domain.Models;
using EVChargingPort.API.Infrastructure.Repositories;

namespace EVChargingPort.API.Application.Services;

/// <inheritdoc />
public class VrnService : IVrnService
{
    /// <inheritdoc />
    public Eligibility CheckEligibility(string vrn)
    {
        return new Eligibility()
            {
                Eligible = vrn[0] == 'E'
            };
    }
}
