using AcoTerra.Core.Entities.Trucks;

namespace AcoTerra.Core.Features.Trailers.SearchTrailers;

public sealed record TrailerSearchResultDto(
    int Id,
    string LicensePlate
)
{
    public static explicit operator TrailerSearchResultDto(Trailer trailer)
    {
        return new TrailerSearchResultDto(
            Id: trailer.Id,
            LicensePlate: trailer.LicensePlate
        );
    }
}