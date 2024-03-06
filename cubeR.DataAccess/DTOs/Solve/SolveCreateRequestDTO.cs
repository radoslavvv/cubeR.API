namespace cubeR.DataAccess.DTOs.Solve;

public record SolveCreateRequestDTO(string SolveType, int CubeId, string Scramble, DateTime LoggedDate, string SolveTime);
