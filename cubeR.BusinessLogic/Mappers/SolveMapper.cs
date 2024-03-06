using cubeR.DataAccess.DTOs.Solve;
using cubeR.DataAccess.Enums;
using cubeR.DataAccess.Models;

namespace cubeR.BusinessLogic.Mappers;

public static class SolveMapper
{
    public static SolveDTO ToSolveDTO(this Solve solveModel)
    {
        return new SolveDTO(solveModel.Id, solveModel.SolveType, solveModel.CubeId, solveModel.Scramble, solveModel.LoggedDate, solveModel.SolveTime);
    }

    public static Solve FromCreateRequestDTOToSolve(this SolveCreateRequestDTO solveCreateRequestDTO)
    {
        return new Solve
        {
            LoggedDate = solveCreateRequestDTO.LoggedDate,
            CubeId = solveCreateRequestDTO.CubeId,
            Scramble = solveCreateRequestDTO.Scramble,
            SolveTime = TimeSpan.Parse(solveCreateRequestDTO.SolveTime),
            SolveType = (SolveType)Enum.Parse(typeof(SolveType), solveCreateRequestDTO.SolveType)
        };
    }
}

