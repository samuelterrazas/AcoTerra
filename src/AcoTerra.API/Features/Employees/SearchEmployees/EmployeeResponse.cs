using AcoTerra.API.Data.Entities.Employees;

namespace AcoTerra.API.Features.Employees.SearchEmployees;

internal sealed record EmployeeResponse(
    int Id,
    string Name,
    string IdentificationType,
    string IdentificationNumber,
    string PhoneNumber,
    string? Email,
    string EmploymentStatus,
    DateOnly DateOfBirth
)
{
    public static explicit operator EmployeeResponse(Employee employee)
    {
        return new EmployeeResponse(
            Id: employee.Id,
            Name: employee.Name,
            IdentificationType: Enum.GetName(employee.IdentificationType)!,
            IdentificationNumber: employee.IdentificationNumber,
            PhoneNumber: employee.PhoneNumber,
            Email: employee.Email,
            EmploymentStatus: Enum.GetName(employee.EmploymentStatus)!,
            DateOfBirth: employee.DateOfBirth
        );
    }
}