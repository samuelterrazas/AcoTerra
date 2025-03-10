using AcoTerra.Core.Entities.Trucks;

namespace AcoTerra.Core.Common.DTOs;

public sealed record TrailerDto(
    int Id,
    string LicensePlate,
    decimal Capacity
)
{
    public static explicit operator TrailerDto(Trailer trailer)
    {
        return new TrailerDto(
            Id: trailer.Id,
            LicensePlate: trailer.LicensePlate,
            Capacity: trailer.Capacity
        );
    }
}