using cubeR.DataAccess.Enums;
using System.ComponentModel.DataAnnotations;

namespace cubeR.DTOs
{
    public class SolveCreateRequestDTO
    {
        [EnumDataType(typeof(SolveType), ErrorMessage = "Invalid Solve Type.")]
        public string SolveType { get; set; } = string.Empty;

        public int CubeId { get; set; }
        public string Scramble { get; set; } = string.Empty;

        public DateTime LoggedDate { get; set; }

        [RegularExpression(@"^(\d{1,2}:)?[0-5]?\d:[0-5]?\d$", ErrorMessage = "Invalid Solve Time.")]
        public string SolveTime { get; set; } = string.Empty;
    }
}
