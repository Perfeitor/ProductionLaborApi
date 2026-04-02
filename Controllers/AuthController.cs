using Microsoft.AspNetCore.Mvc;
using ProductionLaborApi.Data;
using ProductionLaborApi.Models;
using ProductionLaborApi.Services;

namespace ProductionLaborApi.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody]LoginModel model)
    {
        if (await _authService.Register(model))
            return Ok(new { message = "Registration successful" });
        return BadRequest(new { message = "Username already exists" });
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody]LoginModel model)
    {
        if (await _authService.Login(model))
        {
            var token = await _authService.GenJwtToken(model.Username);
            return Ok(token);
        }
        return Unauthorized(new { message = "Invalid username or password" });
    }
}