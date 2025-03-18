using AcoTerra.Core.Entities.Trucks;

namespace AcoTerra.Core.Features.Trailers.GetTrailers;

public sealed record TrailerListDto(
    int Id,
    string LicensePlate,
    decimal Capacity
)
{
    public static explicit operator TrailerListDto(Trailer trailer)
    {
        return new TrailerListDto(
            Id: trailer.Id,
            LicensePlate: trailer.LicensePlate,
            Capacity: trailer.Capacity
        );
    }
}