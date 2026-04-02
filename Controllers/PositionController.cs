using Microsoft.AspNetCore.Mvc;
using ProductionLaborApi.Services;

namespace ProductionLaborApi.Controllers;

[ApiController]
[Route("api/position")]
public class PositionController : ControllerBase
{
    private readonly PositionService _positionService;

    public PositionController(PositionService positionService)
    {
        _positionService = positionService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetPositions()
    {
        return Ok(await _positionService.GetPositions());
    }
}