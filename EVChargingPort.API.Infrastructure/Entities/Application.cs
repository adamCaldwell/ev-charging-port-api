using EVChargingPort.API.Domain.Models;

namespace EVChargingPort.API.Infrastructure.Entities;

public class Application
{
    public int? Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? VRN { get; set; }

    public string? Address { get; set; }
}
