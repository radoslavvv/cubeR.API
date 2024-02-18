using cubeR.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cubeR.BusinessLogic.Services.Contracts;
public interface ICubeService
{
    Task<List<CubeDTO>> GetCubesAsync();
    Task<CubeDTO> GetCubeByIdAsync(int id);

}
