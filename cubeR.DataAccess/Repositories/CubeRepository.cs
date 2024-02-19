using Microsoft.EntityFrameworkCore;

namespace cubeR.DataAccess
{
    public class CubeRepository : ICubeRepository
    {
        private readonly ApplicationDbContext _context;

        public CubeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Cube> CreateCubeAsync(Cube cubeModel)
        {
            await _context.Cubes.AddAsync(cubeModel);
            await _context.SaveChangesAsync();

            return cubeModel;
        }

        public async Task<Cube?> DeleteCubeAsync(int id)
        {
            Cube? cubeModel = _context.Cubes.FirstOrDefault(c => c.Id == id);

            if(cubeModel is null)
            {
                return null;
            }

            _context.Cubes.Remove(cubeModel);
            await _context.SaveChangesAsync();

            return cubeModel;
        }

        public async Task<List<Cube>> GetAllCubesAsync()
        {
            return await _context.Cubes.ToListAsync();
        }

        public async Task<Cube?> GetCubeByIdAsync(int id)
        {
            return await _context.Cubes.FirstOrDefaultAsync(c=>c.Id == id);
        }

        public async Task<Cube?> UpdateCubeAsync(int id, CubeUpdateRequestDTO updateCubeRequestDTO)
        {
            Cube? cubeModel = await _context.Cubes.FirstOrDefaultAsync(c => c.Id == id);

            if(cubeModel is null)
            {
                return null;
            }

            cubeModel.Name = updateCubeRequestDTO.Name;
            cubeModel.SidesCount = updateCubeRequestDTO.SidesCount;
            cubeModel.PiecesCount = updateCubeRequestDTO.PiecesCount;

            await _context.SaveChangesAsync();

            return cubeModel;
        }
    }
}
