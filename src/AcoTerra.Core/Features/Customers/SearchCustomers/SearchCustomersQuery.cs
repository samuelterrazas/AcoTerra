using AcoTerra.Core.Common.Abstractions;
using AcoTerra.Core.Common.Abstractions.Messaging;
using AcoTerra.Core.Entities.Customers;
using Microsoft.EntityFrameworkCore;

namespace AcoTerra.Core.Features.Customers.SearchCustomers;

public sealed record SearchCustomersQuery : IQuery<List<CustomerResponse>>;


internal sealed class SearchCustomersQueryHandler(
    IApplicationDbContext dbContext
) : IQueryHandler<SearchCustomersQuery, List<CustomerResponse>>
{
    public async Task<List<CustomerResponse>> Handle(SearchCustomersQuery request, CancellationToken cancellationToken)
    {
        return await dbContext
            .EntitySetFor<Customer>()
            .Select(customer => (CustomerResponse)customer)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
}