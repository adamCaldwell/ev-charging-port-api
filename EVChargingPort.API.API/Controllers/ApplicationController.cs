using Microsoft.AspNetCore.Mvc;
using EVChargingPort.API.Application.Services;
using EVChargingPort.API.Domain.Models;
using AutoMapper;

namespace EVChargingPort.API.API.Controllers;

/// <summary>
/// Controller for handling location requests.
/// </summary>
[Route("v{version:apiVersion}/locations")]
[ApiController]
public class ApplicationsController : ControllerBase
{
    private readonly IApplicationService _applicationService;

    /// <summary>
    /// Default constructor.
    /// </summary>
    /// <param name="locationService">Service for handling location requests.</param>
    public ApplicationsController(IApplicationService applicationService)
    {
        _applicationService = applicationService;
    }

    /// <summary>
    /// Retrieves location information in WGS84 format by postcode.
    /// </summary>
    /// <param name="application">Location's postcode.</param>
    /// <returns>Returns a Location in Eastings/Northings format by postcode.</returns>
    [HttpPost("/submit")]
    public async Task Submit(UserApplication application)
    {
        await _applicationService.Submit(application);

        return;
    }
}
