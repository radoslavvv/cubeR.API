using cubeR.DataAccess.DataContext;
using cubeR.DataAccess.Models;
using cubeR.DataAccess.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace cubeR.DataAccess.Repositories;
public class SolveRepository : ISolveRepository
{
    private readonly ApplicationDbContext _context;

    public SolveRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Solve> CreateSolveAsync(Solve solveModel)
    {
        await _context.Solves.AddAsync(solveModel);
        await _context.SaveChangesAsync();

        return solveModel;
    }

    public async Task<List<Solve>> GetAllSolvesAsync()
    {
        return await _context.Solves.ToListAsync();
    }

    public async Task<Solve?> GetSolveByIdAsync(int id)
    {
        return await _context.Solves.FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<List<Solve>> GetLastNSolvesAsync(int n)
    {
        return await _context.Solves.OrderByDescending(s => s.Id).Take(n).ToListAsync();
    }

    public async Task<Solve?> DeleteSolveAsync(int id)
    {
        Solve? solveModel = await _context.Solves.FirstOrDefaultAsync(s => s.Id == id);

        if (solveModel is null)
        {
            return null;
        }

        _context.Solves.Remove(solveModel);
        await _context.SaveChangesAsync();

        return solveModel;
    }
}