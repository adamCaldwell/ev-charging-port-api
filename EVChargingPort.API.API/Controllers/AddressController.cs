using Microsoft.AspNetCore.Mvc;

namespace EVChargingPort.API.API.Controllers;

/// <summary>
/// Controller for handling location requests.
/// </summary>
[Route("v{version:apiVersion}/locations")]
[ApiController]
public class AddressController : ControllerBase
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
    /// <param name="address">Location's postcode.</param>
    /// <returns>Returns a Location in Eastings/Northings format by postcode.</returns>
    [HttpGet("/postcode-lookup/{postcode}")]
    public IActionResult PostcodeLookup(string postcode)
    {
        return Ok("postcode eligible");
    }

    /// <summary>
    /// Retrieves location information in WGS84 format by postcode.
    /// </summary>
    /// <param name="address">Location's postcode.</param>
    /// <returns>Returns a Location in Eastings/Northings format by postcode.</returns>
    [HttpPost("/address-eligibility")]
    public IActionResult CheckAddressEligibility(string address)
    {
        return Ok("address");
    }
}
