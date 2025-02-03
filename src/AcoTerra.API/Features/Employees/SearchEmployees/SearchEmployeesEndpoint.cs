using AcoTerra.API.Common.Abstractions;
using AcoTerra.API.Data.Entities.Actors.Enums;
using AcoTerra.API.Data.Entities.Employees;
using AcoTerra.API.Data.Entities.Employees.Enums;
using Bogus;
using Bogus.Extensions.UnitedStates;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace AcoTerra.API.Features.Employees.SearchEmployees;

internal sealed class SearchEmployeesEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) =>
        app.MapGet("/", Handle);
    
    private static async Task<Ok<List<EmployeeResponse>>> Handle(
        IApplicationDbContext dbContext,
        CancellationToken cancellationToken
    )
    {
        List<EmployeeResponse> employees = await dbContext
            .EntitySetFor<Employee>()
            .Select(employee => (EmployeeResponse)employee)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
        
        
        return TypedResults.Ok(employees);
    }
}