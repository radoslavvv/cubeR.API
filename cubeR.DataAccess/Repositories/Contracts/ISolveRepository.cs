using cubeR.DataAccess.DTOs.Solve;
using cubeR.DataAccess.Models;

namespace cubeR.DataAccess.Repositories.Contracts;

public interface ISolveRepository
{
    Task<IEnumerable<Solve>> GetSolvesAsync();

    Task<Solve?> GetSolveByIdAsync(int id);

    Task<Solve> CreateSolveAsync(Solve solveModel);

    Task<Solve?> DeleteSolveAsync(int id);
}

