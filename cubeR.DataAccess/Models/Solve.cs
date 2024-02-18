using cubeR.DataAccess.Enums;
using cubeR.DataAccess.Models;

namespace cubeR.DataAccess
{
    public class Solve
    {
        public int Id { get; set; }

        public SolveType SolveType { get; set; } = SolveType.Default;

        public int CubeId { get; set; }
        public Cube? Cube { get; set; }
        public string Scramble { get; set; } = string.Empty;

        public DateTime LoggedDate { get; set; } = DateTime.Now;

        public TimeSpan SolveTime { get; set; }

        public int UserId { get; set; }

        public User? User { get; set; }
    }
}
