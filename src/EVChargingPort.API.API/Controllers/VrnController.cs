using System.Text.RegularExpressions;
using EVChargingPort.API.Application.Services;
using EVChargingPort.API.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace EVChargingPort.API.API.Controllers;

/// <summary>
/// Controller for handling vrn requests.
/// </summary>
[Route("v{version:apiVersion}")]
[ApiController]
public class VrnController : ControllerBase
{
    private readonly IVrnService _vrnService;

    /// <summary>
    /// Default constructor.
    /// </summary>
    /// <param name="vrnService">Service for handling vrn requests.</param>
    public VrnController(IVrnService vrnService)
    {
        _vrnService = vrnService;
    }

    /// <summary>
    /// Checks if a VRN is eligible.
    /// </summary>
    /// <param name="vrn">Vrn to check if eligible.</param>
    /// <returns>A value indicating whether the vrn is eligible.</returns>
    [HttpPost("/vrn-eligibility/{vrn}")]
    public ActionResult<Eligibility> CheckVrnEligibility([FromRoute] string vrn)
    {
        Regex vrnRegex = new(Patterns.vrnPattern);

        if (!vrnRegex.Match(vrn).Success) { return BadRequest("Invalid VRN entered."); }

        return _vrnService.CheckEligibility(vrn);
    }
}
