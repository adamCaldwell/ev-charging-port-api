using EVChargingPort.API.Domain.Models;

namespace EVChargingPort.API.Application.Services;

public interface IAddressService
{
    List<Address> PostcodeLookup(string postcode);

    Eligibility CheckEligibility(Address address);
}
