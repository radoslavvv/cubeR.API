using cubeR.BusinessLogic.Services.Contracts;
using cubeR.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cubeR.BusinessLogic.Services;

public class CubeService : ICubeService
{
    private readonly ICubeRepository _cubeRepository;

    public CubeService(ICubeRepository cubeRepository)
    {
        _cubeRepository = cubeRepository;
    }

    public Task<CubeDTO> GetCubeByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<CubeDTO>> GetCubesAsync()
    {
        List<Cube> cubes = await _cubeRepository.GetAllCubesAsync();

        List<CubeDTO> cubeDTOs = cubes.Select(c => c.ToCubeDTO()).ToList();

        return cubeDTOs;
    }
}
