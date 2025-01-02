using Microsoft.AspNetCore.Mvc;

namespace EVChargingPort.API.API.Controllers;

/// <summary>
/// Controller for handling location requests.
/// </summary>
[Route("v{version:apiVersion}/locations")]
[ApiController]
public class VRNController : ControllerBase
{
    // private readonly IApplicationService _applicationService;

    // /// <summary>
    // /// Default constructor.
    // /// </summary>
    // /// <param name="locationService">Service for handling location requests.</param>
    // public ApplicationsController(IApplicationService applicationService)
    // {
    //     _applicationService = applicationService;
    // }

    /// <summary>
    /// Retrieves location information in WGS84 format by postcode.
    /// </summary>
    /// <param name="vrn">Location's postcode.</param>
    /// <returns>Returns a Location in Eastings/Northings format by postcode.</returns>
    [HttpPost("/vrn-eligibility/{vrn}")]
    public IActionResult CheckVrnEligibility(string vrn)
    {
        return Ok("vehicle");
    }
}
