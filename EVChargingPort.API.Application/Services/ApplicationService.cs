using EVChargingPort.API.Domain.Models;
using EVChargingPort.API.Infrastructure.Repositories;

namespace EVChargingPort.API.Application.Services;

/// <inheritdoc />
public class ApplicationService : IApplicationService
{
    private readonly IApplicationRepository _applicationRepository;

    /// <summary>
    /// Default constructor.
    /// </summary>
    /// <param name="locationService">Service for handling location requests.</param>
    public ApplicationService(IApplicationRepository applicationRepository)
    {
        _applicationRepository = applicationRepository;
    }

    /// <inheritdoc />
    public async Task Submit(UserApplication application)
    {
        await _applicationRepository.AddApplicationAsync(application);

        return;
    }
}
