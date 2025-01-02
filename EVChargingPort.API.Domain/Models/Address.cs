namespace EVChargingPort.API.Domain.Models;

public class Address
{
    public required string StreetAddress { get; set; }
    public required string City { get; set; }
    public required string Postcode { get; set; }
    public required string Country { get; set; }
}
