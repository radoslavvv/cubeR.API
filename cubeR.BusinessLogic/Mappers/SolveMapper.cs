using cubeR.DataAccess;
using cubeR.DataAccess.Enums;

namespace cubeR.BusinessLogic
{
    public static class SolveMapper
    {

        public static SolveDTO ToSolveDTO(this Solve solveModel)
        {
            return new SolveDTO
            {
                Id = solveModel.Id,
                CubeId = solveModel.CubeId,
                LoggedDate = solveModel.LoggedDate,
                Scramble = solveModel.Scramble,
                SolveTime = solveModel.SolveTime,
                SolveType = solveModel.SolveType
            };
        }

        public static Solve FromCreateRequestDTOToSolve(this SolveCreateRequestDTO solveCreateRequestDTO)
        {
            return new Solve
            {
                LoggedDate = solveCreateRequestDTO.LoggedDate,
                CubeId = solveCreateRequestDTO .CubeId,
                Scramble = solveCreateRequestDTO.Scramble,
                SolveTime = TimeSpan.Parse(solveCreateRequestDTO.SolveTime),
                SolveType = (SolveType)Enum.Parse(typeof(SolveType), solveCreateRequestDTO.SolveType)
            };
        }
    }
}
