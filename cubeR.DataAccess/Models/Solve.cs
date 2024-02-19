using cubeR.DataAccess.Enums;

namespace cubeR.DataAccess
{
    public class Solve
    {
        public int Id { get; set; }

        public SolveType SolveType { get; set; } = SolveType.TwoHands;

        public int CubeId { get; set; }

        public Cube? Cube { get; set; }

        public string Scramble { get; set; } = string.Empty;

        public DateTime LoggedDate { get; set; } = DateTime.Now;

        public TimeSpan SolveTime { get; set; }
    }
}
