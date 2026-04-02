using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProductionLaborApi.Data;
using ProductionLaborApi.Models;

namespace ProductionLaborApi.Services;

public class AuthService
{
    private readonly ApplicationDbContext _db;
    private readonly IConfiguration _configuration;

    public AuthService(ApplicationDbContext db, IConfiguration configuration)
    {
        _db = db;
        _configuration = configuration;
    }

    public async Task<bool> Register(LoginModel model)
    {
        if (await _db.Users.AnyAsync(u => u.Username == model.Username))
            return false;
        var user = new User
        {
            Username = model.Username,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password)
        };
        _db.Users.Add(user);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Login(LoginModel model)
    {
        var user = await _db.Users.FirstOrDefaultAsync(u => u.Username == model.Username);
        if (user == null)
            return false;
        if (BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash))
            return true;
        return false;
    }

    public async Task<string> GenJwtToken(string username)
    {
        var user = (await _db.Users.FirstOrDefaultAsync(u => u.Username == username))!;
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]!);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity([
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, "User")
            ]),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            Issuer = _configuration["Jwt:Issuer"],
            Audience = _configuration["Jwt:Audience"]
        };
        
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}