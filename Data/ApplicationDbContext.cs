using Microsoft.EntityFrameworkCore;
using ProductionLaborApi.Models;

namespace ProductionLaborApi.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Position> Positions { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<WorkLog> WorkLogs { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Position>(p =>
        {
            p.HasKey(x => x.Id);
        });
        
        builder.Entity<Employee>(e =>
        {
            e.HasKey(x => x.Id);
        });

        builder.Entity<WorkLog>(e =>
        {
            e.HasKey(x => x.Id);
            e.HasIndex(x => new { x.EmployeeId, x.WorkDate }).IsUnique();
        });
        
        builder.Entity<User>(u =>
        {
            u.HasKey(x => x.Id);
            u.HasIndex(x => x.Username).IsUnique();
        });
    }
}