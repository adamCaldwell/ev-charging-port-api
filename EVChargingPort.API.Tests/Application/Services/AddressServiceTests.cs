using EVChargingPort.API.Domain.Models;

namespace EVChargingPort.API.Application.Services;

public class AddressServiceTests
{
    [InlineData("M263GL", "Manchester", "England")]
    [InlineData("I263GL", "Douglas", "Isle of Man")]
    [Theory]
    public void ShouldReturnCorrectAddressForPostcode(string postcode, string expectedCity, string expectedCountry)
    {
        // Arrange
        AddressService addressService = new AddressService();

        // Act
        List<Address> addresses = addressService.PostcodeLookup(postcode);

        // Assert
        Assert.NotNull(addresses);
        Assert.Equal(20, addresses.Count);
        Assert.Equal("1 Fake Street", addresses[0].StreetAddress);
        Assert.Equal(expectedCity, addresses[0].City);
        Assert.Equal(expectedCountry, addresses[0].Country);
        Assert.Equal(postcode, addresses[0].Postcode);
    }

    [InlineData("England", true)]
    [InlineData("Scotland", true)]
    [InlineData("Wales", true)]
    [InlineData("Northern Ireland", true)]
    [InlineData("Isle of Man", false)]
    [InlineData("Channel Islands", false)]
    [Theory]
    public void ShouldReturnCorrectEligibilityForAddress(string addressCountry, bool expectedEligibility)
    {
        // Arrange
        Address address = new Address
        {
            StreetAddress = "111 Not real street",
            City = "Fake City",
            Country = addressCountry,
            Postcode = "M263GL"
        };
        AddressService addressService = new AddressService();

        // Act
        Eligibility eligibility = addressService.CheckEligibility(address);

        // Assert
        Assert.NotNull(eligibility);
        Assert.Equal(expectedEligibility, eligibility.Eligible);
    }


    
}