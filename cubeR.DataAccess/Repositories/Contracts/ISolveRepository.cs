namespace cubeR.DataAccess
{
    public interface ISolveRepository
    {
        Task<List<Solve>> GetAllSolvesAsync();

        Task<List<Solve>> GetLastNSolvesAsync(int n);

        Task<Solve?> GetSolveByIdAsync(int id);

        Task<Solve> CreateSolveAsync(Solve solveModel);

        Task<Solve?> DeleteSolveAsync(int id);
    }
}
