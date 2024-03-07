using cubeR.DataAccess.DTOs.Cube;
using cubeR.DataAccess.Models;

namespace cubeR.DataAccess.Repositories.Contracts;

public interface ICubeRepository
{
    Task<IEnumerable<Cube>> GetCubesAsync();

    Task<Cube?> GetCubeByIdAsync(int id);

    Task<Cube> CreateCubeAsync(Cube cubeModel);

    Task<Cube?> UpdateCubeAsync(int id, CubeUpdateRequestDTO updateCubeRequestDTO);

    Task<Cube?> DeleteCubeAsync(int id);
}

