using Microsoft.EntityFrameworkCore;
using ProductionLaborApi.Data;
using ProductionLaborApi.Models;

namespace ProductionLaborApi.Services;

public class EmployeeService
{
    private readonly ApplicationDbContext _db;
    public EmployeeService(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task AddEmployees(List<Employee> employees)
    {
        await _db.AddRangeAsync(employees);
        await _db.SaveChangesAsync();
    }

    public async Task<List<Employee>> GetEmployees()
    {
        return await _db.Employees.ToListAsync();
    }
}