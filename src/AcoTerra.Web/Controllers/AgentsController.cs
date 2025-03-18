using AcoTerra.Web.Models.Agents;
using AcoTerra.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace AcoTerra.Web.Controllers;

public sealed class AgentsController(IAgentService service) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index([FromQuery] AgentType type, CancellationToken cancellationToken)
    {
        if (type == 0)
        {
            type = AgentType.Driver;
        }
        
        List<AgentViewModel> agents = await service.GetAgents(type, cancellationToken);

        var model = new AgentListViewModel
        {
            Type = type,
            Agents = agents,
        };

        return View("Index", model);
    }
}