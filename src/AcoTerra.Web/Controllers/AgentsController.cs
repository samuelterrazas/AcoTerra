using AcoTerra.Core.Entities.Agents.Enums;
using AcoTerra.Core.Features.Agents.GetAgents;
using AcoTerra.Web.Models.Agents;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AcoTerra.Web.Controllers;

public sealed class AgentsController(ISender sender) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index([FromQuery] AgentType type)
    {
        List<AgentListDto> agents = await sender.Send(new GetAgentsQuery(type));

        var model = new AgentListViewModel
        {
            Type = type,
            Agents = agents,
        };

        return View("Index", model);
    }
}