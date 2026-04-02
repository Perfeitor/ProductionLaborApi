using System.ComponentModel.DataAnnotations.Schema;

namespace ProductionLaborApi.Models;

[Table("User")]
public class User
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public required string Username { get; set; }
    public required string PasswordHash { get; set; }
    [NotMapped]
    public string? Password { get; set; }
}