using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductionLaborApi.Models;

[Table("Employees")]
public class Employee
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public required string EmployeeCode { get; set; }
    public required string FullName { get; set; }
    public bool IsActive { get; set; } = true;
}