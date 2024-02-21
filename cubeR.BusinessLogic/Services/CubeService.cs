using cubeR.BusinessLogic.Mappers;
using cubeR.BusinessLogic.Services.Contracts;
using cubeR.DataAccess;
using cubeR.DataAccess.DTOs.Cube;
using cubeR.DataAccess.Models;
using cubeR.DataAccess.Repositories.Contracts;

namespace cubeR.BusinessLogic.Services;

public class CubeService : ICubeService
{
    private readonly ICubeRepository _cubeRepository;

    public CubeService(ICubeRepository cubeRepository)
    {
        _cubeRepository = cubeRepository;
    }

    public async Task<CubeDTO> CreateCubeAsync(CubeCreateRequestDTO cubeCreateRequestDTO)
    {
        Cube cubeModel = cubeCreateRequestDTO.FromCreateRequestDTOToCube();
        Cube createdCube = await _cubeRepository.CreateCubeAsync(cubeModel);

        return createdCube.ToCubeDTO();
    }

    public async Task<CubeDTO?> DeleteCubeAsync(int id)
    {
        Cube? cubeModel = await _cubeRepository.DeleteCubeAsync(id);
        return cubeModel?.ToCubeDTO();
    }

    public async Task<List<CubeDTO>> GetAllCubesAsync()
    {
        List<Cube> cubes = await _cubeRepository.GetAllCubesAsync();
        List<CubeDTO> cubeDTOs = cubes.Select(c => c.ToCubeDTO()).ToList();

        return cubeDTOs;
    }

    public async Task<CubeDTO?> GetCubeByIdAsync(int id)
    {
        Cube? cube = await _cubeRepository.GetCubeByIdAsync(id);
        return cube?.ToCubeDTO(); 
    }

    public async Task<CubeDTO?> UpdateCubeAsync(int id, CubeUpdateRequestDTO cubeUpdateRequestDTO)
    {
        Cube? cubeModel = await _cubeRepository.UpdateCubeAsync(id, cubeUpdateRequestDTO);
        return cubeModel?.ToCubeDTO();
    }
}
