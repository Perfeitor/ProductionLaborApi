using System.ComponentModel.DataAnnotations.Schema;

namespace ProductionLaborApi.Models;

[Table("User")]
public class User
{
    public long Id { get; set; }
    public string Username { get; set; } = default!;
    public string PasswordHash { get; set; } = default!;
}