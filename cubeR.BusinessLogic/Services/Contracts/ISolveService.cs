using cubeR.DataAccess.DTOs.Solve;

namespace cubeR.BusinessLogic.Services.Contracts;
public interface ISolveService
{
    Task<List<SolveDTO>> GetAllSolvesAsync();

    Task<List<SolveDTO>> GetLastNSolvesAsync(int count);

    Task<SolveDTO?> GetSolveByIdAsync(int id);

    Task<SolveDTO> CreateSolveAsync(SolveCreateRequestDTO solveCreateRequestDTO);

    Task<SolveDTO?> DeleteSolveAsync(int id);
}