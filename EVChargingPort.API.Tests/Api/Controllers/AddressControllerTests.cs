using EVChargingPort.API.Application.Services;
using EVChargingPort.API.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace EVChargingPort.API.API.Controllers;

public class AddressControllerTests
{
    [InlineData("M263GLJIDHFIFH")]
    [InlineData("abc")]
    [InlineData("abc26354")]
    [Theory]
    public void ShouldReturnBadRequestForInvalidPostcodeInPostcodeLookup(string invalidPostcode)
    {
        // Arrange
        Address invalidAddress = new Address
        {
            StreetAddress = "Invalid Address House",
            City = "Invalid Town",
            Country = "Invalid Country",
            Postcode = invalidPostcode
        };
        AddressService addressService = new AddressService();
        AddressController addressController = new AddressController(addressService);

        // Act
        ActionResult<Eligibility> response = addressController.CheckAddressEligibility(invalidAddress);

        // Assert
        Assert.NotNull(response);
        Assert.IsType<BadRequestObjectResult>(response.Result);
    }

    [InlineData("M263GLJIDHFIFH")]
    [InlineData("abc")]
    [InlineData("abc26354")]
    [Theory]
    public void ShouldReturnBadRequestForInvalidPostcodeInCheckAddressEligibility(string invalidPostcode)
    {
        // Arrange
        AddressService addressService = new AddressService();
        AddressController addressController = new AddressController(addressService);

        // Act
        ActionResult<List<Address>> response = addressController.PostcodeLookup(invalidPostcode);

        // Assert
        Assert.NotNull(response);
        Assert.IsType<BadRequestObjectResult>(response.Result);
    }
}