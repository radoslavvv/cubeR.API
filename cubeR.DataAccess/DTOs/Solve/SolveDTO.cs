using cubeR.DataAccess.Enums;

namespace cubeR.DataAccess.DTOs.Solve;

public record SolveDTO(int Id, SolveType SolveType, int? CubeId, string Scramble, DateTime LoggedDate, TimeSpan SolveTime);