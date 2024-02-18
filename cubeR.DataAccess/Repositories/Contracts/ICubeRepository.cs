namespace cubeR.DataAccess
{
    public interface ICubeRepository
    {
        Task<List<Cube>> GetAllCubesAsync();

        Task<Cube?> GetCubeByIdAsync(int id);

        Task<Cube> CreateCubeAsync(Cube cubeModel);

        Task<Cube?> UpdateCubeAsync(int id, CubeUpdateRequestDTO updateCubeRequestDTO);

        Task<Cube?> DeleteCubeAsync(int id);
    }
}
