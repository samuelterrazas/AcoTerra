using AcoTerra.API.Data.Entities.Trucks;

namespace AcoTerra.API.Features.Common.DTOs;

internal sealed record TrailerDto(
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