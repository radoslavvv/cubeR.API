using cubeR.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cubeR.BusinessLogic.Services.Contracts;
public interface ISolveService
{
    Task<List<SolveDTO>> GetAllSolvesAsync();
    Task<List<SolveDTO>> GetLastNSolvesAsync(int count);
    Task<SolveDTO?> GetSolveByIdAsync(int id);
    Task<SolveDTO> CreateSolveAsync(SolveCreateRequestDTO solveCreateRequestDTO);
}