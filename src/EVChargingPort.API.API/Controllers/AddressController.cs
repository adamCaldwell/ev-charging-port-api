using System.Text.RegularExpressions;
using EVChargingPort.API.Application.Services;
using EVChargingPort.API.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace EVChargingPort.API.API.Controllers;

/// <summary>
/// Controller for handling address requests.
/// </summary>
[Route("v{version:apiVersion}")]
[ApiController]
public class AddressController : ControllerBase
{
    private readonly IAddressService _addressService;

    /// <summary>
    /// Default constructor.
    /// </summary>
    /// <param name="addressService">Service for handling address requests.</param>
    public AddressController(IAddressService addressService)
    {
        _addressService = addressService;
    }

    /// <summary>
    /// Retrieves a list of addresses matching a given postcode.
    /// </summary>
    /// <param name="postcode">The postcode to lookup.</param>
    /// <returns>Returns a list of addresses</returns>
    [HttpGet("/postcode-lookup/{postcode}")]
    public ActionResult<List<Address>> PostcodeLookup(string postcode)
    {
        Regex postcodeRegex = new(Patterns.postcodePattern);

        if (!postcodeRegex.Match(postcode).Success)
        {
            return BadRequest("Invalid postcode entered.");
        }

        return _addressService.PostcodeLookup(postcode);
    }

    /// <summary>
    /// Checks if a given address is eligible.
    /// </summary>
    /// <param name="address">Address to check eligiblity for.</param>
    /// <returns>A value indicating whether the address is eligible.</returns>
    [HttpPost("/address-eligibility")]
    public ActionResult<Eligibility> CheckAddressEligibility(Address address)
    {
        Regex postcodeRegex = new(Patterns.postcodePattern);

        if (!postcodeRegex.Match(address.Postcode).Success) { return BadRequest("Address has invalid postcode."); }

        return _addressService.CheckEligibility(address);
    }
}
