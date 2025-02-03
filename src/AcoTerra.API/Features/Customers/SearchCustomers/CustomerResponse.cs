using AcoTerra.API.Data.Entities.Customers;

namespace AcoTerra.API.Features.Customers.SearchCustomers;

internal sealed record CustomerResponse(
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