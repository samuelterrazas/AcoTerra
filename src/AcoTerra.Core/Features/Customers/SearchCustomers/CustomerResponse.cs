using AcoTerra.Core.Entities.Customers;

namespace AcoTerra.Core.Features.Customers.SearchCustomers;

public sealed record CustomerResponse(
    int Id,
    string Name,
    string IdentificationType,
    string IdentificationNumber,
    string PhoneNumber,
    string? Email
)
{
    public static explicit operator CustomerResponse(Customer customer)
    {
        return new CustomerResponse(
            Id: customer.Id,
            Name: customer.Name,
            IdentificationType: Enum.GetName(customer.IdentificationType)!,
            IdentificationNumber: customer.IdentificationNumber,
            PhoneNumber: customer.PhoneNumber,
            Email: customer.Email
        );
    }
}