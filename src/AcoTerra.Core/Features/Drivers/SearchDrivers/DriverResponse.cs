using AcoTerra.Core.Entities.Drivers;

namespace AcoTerra.Core.Features.Drivers.SearchDrivers;

internal sealed record DriverResponse(
    int Id,
    string Name,
    string IdentificationType,
    string IdentificationNumber,
    string PhoneNumber,
    string? Email,
    string EmploymentStatus,
    DateOnly DateOfBirth
)
{
    public static explicit operator DriverResponse(Driver driver)
    {
        return new DriverResponse(
            Id: driver.Id,
            Name: driver.Name,
            IdentificationType: Enum.GetName(driver.IdentificationType)!,
            IdentificationNumber: driver.IdentificationNumber,
            PhoneNumber: driver.PhoneNumber,
            Email: driver.Email,
            EmploymentStatus: Enum.GetName(driver.EmploymentStatus)!,
            DateOfBirth: driver.DateOfBirth
        );
    }
}