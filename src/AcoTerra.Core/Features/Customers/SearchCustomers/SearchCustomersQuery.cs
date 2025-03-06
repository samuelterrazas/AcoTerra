using AcoTerra.Core.Common.Abstractions.Messaging;

namespace AcoTerra.Core.Features.Customers.SearchCustomers;

public sealed record SearchCustomersQuery : IQuery<List<CustomerResponse>>;