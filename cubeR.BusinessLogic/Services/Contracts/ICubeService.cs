using cubeR.DataAccess;
using cubeR.DataAccess.DTOs.Cube;

namespace cubeR.BusinessLogic.Services.Contracts;
public interface ICubeService
{
    Task<List<CubeDTO>> GetAllCubesAsync();

    Task<CubeDTO?> GetCubeByIdAsync(int id);

    Task<CubeDTO> CreateCubeAsync(CubeCreateRequestDTO cubeCreateRequestDTO);

    Task<CubeDTO?> UpdateCubeAsync(int id, CubeUpdateRequestDTO cubeUpdateRequestDTO);

    Task<CubeDTO?> DeleteCubeAsync(int id);

}
