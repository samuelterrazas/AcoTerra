using AcoTerra.Web.Models.Agents;
using Microsoft.AspNetCore.Mvc;
using Refit;

namespace AcoTerra.Web.Services;

public interface IAgentService
{
    [Get("")]
    Task<List<AgentViewModel>> GetAgents([FromQuery] AgentType type, CancellationToken cancellationToken);
}