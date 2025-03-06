using AcoTerra.API.Common.Abstractions;
using AcoTerra.API.Data.Entities.Customers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace AcoTerra.API.Features.Customers.SearchCustomers;

internal sealed class SearchCustomersEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) =>
        app.MapGet("/", Handle);
    
    private static async Task<Ok<List<CustomerResponse>>> Handle(
        IApplicationDbContext dbContext,
        CancellationToken cancellationToken
    )
    {
        List<CustomerResponse> customers = await dbContext
            .EntitySetFor<Customer>()
            .Select(customer => (CustomerResponse)customer)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
        
        
        return TypedResults.Ok(customers);
    }
}