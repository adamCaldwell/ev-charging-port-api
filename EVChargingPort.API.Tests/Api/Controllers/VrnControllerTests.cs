using EVChargingPort.API.Application.Services;
using EVChargingPort.API.Domain.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EVChargingPort.API.API.Controllers;

public class VrnControllerTests
{
    [InlineData("abc")]
    [InlineData("abc123")]
    [InlineData("MV63AOZHEJKCOS")]
    [Theory]
    public void ShouldReturnBadRequestForInvalidVrn(string InvalidVrn)
    {
        // Arrange
        VrnService vrnService = new VrnService();
        VrnController vrnController = new VrnController(vrnService);

        // Act
        ActionResult<Eligibility> response = vrnController.CheckVrnEligibility(InvalidVrn);

        // Assert
        Assert.NotNull(response);
        Assert.IsType<BadRequestObjectResult>(response.Result);
    }
}