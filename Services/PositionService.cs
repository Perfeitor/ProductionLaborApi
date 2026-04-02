using Microsoft.EntityFrameworkCore;
using ProductionLaborApi.Data;
using ProductionLaborApi.Models;

namespace ProductionLaborApi.Services;

public class PositionService
{
    private readonly ApplicationDbContext _db;
    public  PositionService(ApplicationDbContext db)
    {
        _db = db;
    }
    
    public async Task AddPositions(List<Position> positions)
    {
        await _db.AddRangeAsync(positions);
        await _db.SaveChangesAsync();
    }
    
    public async Task<List<Position>> GetPositions()
    {
        return await _db.Positions.ToListAsync();
    }
}