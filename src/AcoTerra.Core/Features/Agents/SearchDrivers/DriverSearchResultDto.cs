using AcoTerra.Core.Entities.Agents;

namespace AcoTerra.Core.Features.Agents.SearchDrivers;

public sealed record DriverSearchResultDto(
    int Id,
    string Name,
    string IdentificationNumber
)
{
    internal static DriverSearchResultDto Map(Driver driver)
    {
        return new DriverSearchResultDto(
            Id: driver.Id,
            Name: driver.Name,
            IdentificationNumber: driver.IdentificationNumber
        );
    }
}