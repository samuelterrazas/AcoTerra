using AcoTerra.Core.Entities.Agents;
using AcoTerra.Core.Entities.Drivers.Enums;

namespace AcoTerra.Core.Entities.Drivers;

public sealed class Driver : Agent
{
    public required EmploymentStatus EmploymentStatus { get; set; }
    public required DateOnly DateOfBirth { get; set; }
    public string? EmergencyContact { get; set; }
}