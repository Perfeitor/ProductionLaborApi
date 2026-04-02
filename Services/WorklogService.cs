using Microsoft.EntityFrameworkCore;
using ProductionLaborApi.Data;
using ProductionLaborApi.Models;

namespace ProductionLaborApi.Services;

public class WorklogService
{
    private readonly ApplicationDbContext _db;
    public WorklogService(ApplicationDbContext db)
    {
        _db = db;
    }
    
    public async Task AddWorklogs(List<WorkLog> worklogs)
    {
        _db.WorkLogs.AddRange(worklogs);
        await _db.SaveChangesAsync();
    }

    public async Task<List<WorkLog>> GetWorklogs(DateOnly startDate, DateOnly endDate)
    {
        var logs = await _db.WorkLogs.Where(w => w.WorkDate >= startDate && w.WorkDate <= endDate).ToListAsync();
        return logs;
    }
    
}