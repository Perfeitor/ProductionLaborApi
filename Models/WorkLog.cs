using System.ComponentModel.DataAnnotations.Schema;

namespace ProductionLaborApi.Models;

[Table("WorkLog")]
public class WorkLog
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public required string EmployeeId { get; set; }
    public DateOnly WorkDate { get; set; }

    public decimal? Hours { get; set; } // số giờ
    public string Type { get; set; } = "Work";

    public string? Note { get; set; }
}