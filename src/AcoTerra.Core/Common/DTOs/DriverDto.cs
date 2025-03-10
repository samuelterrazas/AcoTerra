using AcoTerra.Core.Entities.Agents;

namespace AcoTerra.Core.Common.DTOs;

public sealed record DriverDto(
    int Id,
    string Name,
    string IdentificationNumber,
    string PhoneNumber
)
{
    public static explicit operator DriverDto(Driver driver)
    {
        return new DriverDto(
            Id: driver.Id,
            Name: driver.Name,
            IdentificationNumber: driver.IdentificationNumber,
            PhoneNumber: driver.PhoneNumber
        );
    }
}