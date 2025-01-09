using EVChargingPort.API.Domain.Models;

namespace EVChargingPort.API.Application.Services;

public class VrnServiceTests
{
    [InlineData("EV63AOZ", true)]
    [InlineData("MV63AOZ", false)]
    [Theory]
    public void ShouldReturnCorrectEligiblityForVrn(string vrn, bool expectedEligibility)
    {
        // Arrange
        VrnService vrnService = new VrnService();

        // Act
        Eligibility eligibility = vrnService.CheckEligibility(vrn);

        // Assert
        Assert.NotNull(eligibility);
        Assert.Equal(expectedEligibility, eligibility.Eligible);
    }
}