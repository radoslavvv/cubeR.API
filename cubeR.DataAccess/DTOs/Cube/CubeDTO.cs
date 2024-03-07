using cubeR.DataAccess.Enums;

namespace cubeR.DataAccess.DTOs.Cube;

public record CubeDTO(int Id, string Name, int SidesCount, int PiecesCount, double Weight, CubeDifficultyLevel DifficultyLevel, int ReleaseYear, string Material);