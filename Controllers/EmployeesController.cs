using Microsoft.AspNetCore.Mvc;

namespace ProductionLaborApi.Controllers;

[ApiController]
[Route("api/nhanvien")]
public class EmployeesController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok("Hello World");
    }
}