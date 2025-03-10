using AcoTerra.Core.Entities.Agents.Enums;
using AcoTerra.Core.Features.Agents.SearchAgents;
using AcoTerra.Web.Models.Agents;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AcoTerra.Web.Controllers;

public sealed class AgentsController(ISender sender) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index([FromQuery] AgentType type)
    {
        List<AgentResponse> agents = await sender.Send(new SearchAgentsQuery(type));

        var model = new AgentListViewModel
        {
            Type = type,
            Agents = agents,
        };

        return View("Index", model);
    }
}