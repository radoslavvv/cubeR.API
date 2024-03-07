using cubeR.DataAccess.DataContext;
using cubeR.DataAccess.DTOs.Cube;
using cubeR.DataAccess.Models;
using cubeR.DataAccess.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace cubeR.DataAccess.Repositories;

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
        Cube? cubeModel = await _context.Cubes.FirstOrDefaultAsync(c => c.Id == id);

        if (cubeModel is null)
        {
            return null;
        }

        _context.Cubes.Remove(cubeModel);
        await _context.SaveChangesAsync();

        return cubeModel;
    }

    public async Task<IEnumerable<Cube>> GetCubesAsync()
    {
        return await _context.Cubes.ToListAsync();
    }

    public async Task<Cube?> GetCubeByIdAsync(int id)
    {
        return await _context.Cubes.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Cube?> UpdateCubeAsync(int id, CubeUpdateRequestDTO updateCubeRequestDTO)
    {
        Cube? cubeModel = await _context.Cubes.FirstOrDefaultAsync(c => c.Id == id);

        if (cubeModel is null)
        {
            return null;
        }

        cubeModel.Name = updateCubeRequestDTO.Name;
        cubeModel.SidesCount = updateCubeRequestDTO.SidesCount;
        cubeModel.PiecesCount = updateCubeRequestDTO.PiecesCount;
        cubeModel.DifficultyLevel = updateCubeRequestDTO.DifficultyLevel;
        cubeModel.ReleaseYear = updateCubeRequestDTO.ReleaseYear;
        cubeModel.Material = updateCubeRequestDTO.Material;
        cubeModel.Weight = updateCubeRequestDTO.Weight;

        await _context.SaveChangesAsync();

        return cubeModel;
    }
}

