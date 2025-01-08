namespace EVChargingPort.API.Domain.Models;

public class UserApplication
{
    public required string Name { get; set; }

    public required string Email { get; set; }

    public required string VRN { get; set; }

    public required Address Address { get; set; }
}
