using Microsoft.AspNetCore.Mvc;
using EVChargingPort.API.Application.Services;
using EVChargingPort.API.Domain.Models;
using System.Text.RegularExpressions;

namespace EVChargingPort.API.API.Controllers;

/// <summary>
/// Controller for handling applications.
/// </summary>
[Route("v{version:apiVersion}")]
[ApiController]
public class ApplicationsController : ControllerBase
{
    private readonly IApplicationService _applicationService;

    /// <summary>
    /// Default constructor.
    /// </summary>
    /// <param name="applicationService">Service for handling applications.</param>
    public ApplicationsController(IApplicationService applicationService)
    {
        _applicationService = applicationService;
    }

    /// <summary>
    /// Submits a User Application.
    /// </summary>
    /// <param name="application">Application to submit.</param>
    [HttpPost("/submit")]
    public async Task<ActionResult> Submit(UserApplication application)
    {
        Regex vrnRegex = new(Patterns.vrnPattern);
        Regex emailRegex = new(Patterns.emailPattern);
        Regex postcodeRegex = new(Patterns.postcodePattern);

        if (!vrnRegex.Match(application.VRN).Success) { return BadRequest("Invalid VRN entered."); }
        if (!emailRegex.Match(application.Email).Success) { return BadRequest("Invalid email entered."); }
        if (!postcodeRegex.Match(application.Address.Postcode).Success) { return BadRequest("Address has invalid postcode."); }

        await _applicationService.Submit(application);

        return Ok();
    }
}
