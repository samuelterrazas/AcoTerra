using AcoTerra.API.Common.Abstractions;
using AcoTerra.API.Data.Entities.Actors.Enums;
using Bogus;
using Bogus.Extensions.UnitedStates;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AcoTerra.API.Features.Producers.SearchProducers;

internal sealed class SearchProducersEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) =>
        app.MapGet("/", Handle);

    private static Ok<List<ProducerResponse>> Handle()
    {
        var producers = new List<ProducerResponse>();

        for (int i = 0; i < 10; i++)
        {
            var faker = new Faker("es");

            var producer = new ProducerResponse(
                Id: i + 1,
                Name: faker.Person.FullName,
                IdentificationType: Enum.GetName(IdentificationType.DNI)!,
                IdentificationNumber: faker.Person.Ssn(),
                PhoneNumber: faker.Person.Phone,
                Email: faker.Person.Email
            );
            
            producers.Add(producer);
        }

        return TypedResults.Ok(producers);
    }
}