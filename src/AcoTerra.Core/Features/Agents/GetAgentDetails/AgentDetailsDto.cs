using System.Text.Json;
using AcoTerra.Core.Common.DTOs;
using AcoTerra.Core.Entities.Agents;

namespace AcoTerra.Core.Features.Agents.GetAgentDetails;

public sealed record AgentDetailsDto(
    int Id,
    string Name,
    string IdentificationType,
    string IdentificationNumber,
    string PhoneNumber,
    string? Email,
    string? EmploymentStatus,
    DateOnly? DateOfBirth,
    EmergencyContactDto? EmergencyContact
)
{
    internal static AgentDetailsDto Map(Agent agent)
    {
        return agent switch
        {
            Driver driver => CreateAgentResponse(
                agent: driver,
                employmentStatus: Enum.GetName(driver.EmploymentStatus),
                dateOfBirth: driver.DateOfBirth,
                emergencyContact: driver.EmergencyContact
            ),
            Producer producer => CreateAgentResponse(producer),
            Customer customer => CreateAgentResponse(customer),
            _ => throw new ArgumentOutOfRangeException(nameof(agent)),
        };
    }

    private static AgentDetailsDto CreateAgentResponse(
        Agent agent,
        string? employmentStatus = null,
        DateOnly? dateOfBirth = null,
        string? emergencyContact = null
    )
    {
        return new AgentDetailsDto(
            Id: agent.Id,
            Name: agent.Name,
            IdentificationType: Enum.GetName(agent.IdentificationType)!,
            IdentificationNumber: agent.IdentificationNumber,
            PhoneNumber: agent.PhoneNumber,
            Email: agent.Email,
            EmploymentStatus: employmentStatus,
            DateOfBirth: dateOfBirth,
            EmergencyContact: emergencyContact is not null
                ? JsonSerializer.Deserialize<EmergencyContactDto>(emergencyContact, JsonSerializerOptions.Web)
                : null
        );
    }
}