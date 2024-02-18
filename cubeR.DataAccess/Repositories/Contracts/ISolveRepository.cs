namespace cubeR.DataAccess
{
    public interface ISolveRepository
    {
        Task<List<Solve>> GetLastNSolvesAsync(int n);

        Task<Solve?> GetByIdAsync(int id);

        Task<Solve> CreateAsync(Solve solveModel);
    }
}
