using cubeR.DataAccess.Enums;

namespace cubeR.DataAccess
{
    public record SolveDTO
    {
        public int Id { get; set; }

        public SolveType SolveType { get; set; }

        public int? CubeId { get; set; }

        public string Scramble { get; set; } = string.Empty;

        public DateTime LoggedDate { get; set; }

        public TimeSpan SolveTime { get; set; }
    }
}
