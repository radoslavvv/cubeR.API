using Microsoft.EntityFrameworkCore;

namespace cubeR.DataAccess
{
    public class SolveRepository : ISolveRepository
    {
        private readonly ApplicationDbContext _context;

        public SolveRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Solve> CreateAsync(Solve solveModel)
        {
            await _context.Solves.AddAsync(solveModel);
            await _context.SaveChangesAsync();

            return solveModel;
        }

        public async Task<Solve?> GetByIdAsync(int id)
        {
            return await _context.Solves.FirstOrDefaultAsync(s=>s.Id == id);
        }

        public async Task<List<Solve>> GetLastNSolvesAsync(int n)
        {
            return await _context.Solves.OrderByDescending(s => s.Id).Take(n).ToListAsync();
        }
    }
}
