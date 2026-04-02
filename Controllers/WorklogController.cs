using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductionLaborApi.Models;
using ProductionLaborApi.Services;

namespace ProductionLaborApi.Controllers;

[Authorize]
[ApiController]
[Route("api/worklogs")]
public class Worklog : ControllerBase
{
    private readonly WorklogService _worklogService;
    public Worklog(WorklogService worklogService)
    {
        _worklogService = worklogService;
    }
    
    [HttpPost]
    public async Task<IActionResult> AddWorklogs(List<WorkLog> worklogs)
    {
        await _worklogService.AddWorklogs(worklogs);
        return Ok();
    }
    
    [HttpGet]
    public async Task<IActionResult> GetWorklogs([FromQuery]DateOnly startDate, [FromQuery]DateOnly endDate)
    {
        var logs = await _worklogService.GetWorklogs(startDate, endDate);
        return Ok(logs);
    }
}