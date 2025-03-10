using AcoTerra.Core.Entities.Agents.Enums;

namespace AcoTerra.Core.Entities.Agents;

public sealed class Driver : Agent
{
    public required EmploymentStatus EmploymentStatus { get; set; }
    public required DateOnly DateOfBirth { get; set; }
    public string? EmergencyContact { get; set; }
}