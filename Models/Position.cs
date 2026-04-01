using System.ComponentModel.DataAnnotations.Schema;

namespace ProductionLaborApi.Models;

[Table("Position")]
public class Position
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public required string Name { get; set; }
}