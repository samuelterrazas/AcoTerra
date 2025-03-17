namespace AcoTerra.Web.Models.Agents;

public sealed class AgentListViewModel
{
    public AgentType Type { get; init; }
    public List<AgentViewModel> Agents { get; init; } = [];
}

public sealed class AgentViewModel
{
    public int Id { get; init; }
    public int Type { get; init; }
    public string? Name { get; init; }
    public string? IdentificationType { get; init; }
    public string? IdentificationNumber { get; init; }
    public string? PhoneNumber { get; init; }
    public string? Email { get; init; }
    public string? EmploymentStatus { get; init; }
    public DateOnly? DateOfBirth { get; init; }
}