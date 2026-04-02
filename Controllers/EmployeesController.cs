using Microsoft.AspNetCore.Mvc;
using ProductionLaborApi.Services;

namespace ProductionLaborApi.Controllers;

[ApiController]
[Route("api/nhanvien")]
public class EmployeesController : ControllerBase
{
    private readonly EmployeeService _employeeService;
    public EmployeesController(EmployeeService employeeService)
    {
        _employeeService = employeeService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetEmployees()
    {
        return Ok(await _employeeService.GetEmployees());
    }
}