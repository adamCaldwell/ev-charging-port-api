using EVChargingPort.API.Domain.Models;

namespace EVChargingPort.API.Application.Services;

/// <inheritdoc />
public class AddressService : IAddressService
{
    /// <inheritdoc />
    public List<Address> PostcodeLookup(string postcode)
    {
        List<Address> addresses = [];

        for (int i = 1; i <= 20; i++)
        {
            Address address = new()
            {
                StreetAddress = i.ToString() + " Fake Street",
                City = postcode[0] == 'I' ? "Douglas" : "Manchester",
                Postcode = postcode,
                Country = postcode[0] == 'I' ? "Isle of Man" : "England"
            };

            addresses.Add(address);
        }

        return addresses;
    }

    /// <inheritdoc />
    public Eligibility CheckEligibility(Address address)
    {
        List<string> eligibleCountries = new List<string> {"England", "Scotland", "Wales", "Northern Ireland"};
        return new Eligibility()
            {
                Eligible = eligibleCountries.Contains(address.Country)
            };
    }
}
