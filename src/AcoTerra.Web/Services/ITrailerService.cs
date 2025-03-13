using AcoTerra.Web.Models.Trailers;
using Microsoft.AspNetCore.Mvc;
using Refit;

namespace AcoTerra.Web.Services;

public interface ITrailerService
{
    [Get("/")]
    Task<List<TrailerSearchResultViewModel>> SearchTrailer(
        [FromQuery] string? licensePlate,
        CancellationToken cancellationToken
    );
}