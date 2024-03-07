using cubeR.DataAccess.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cubeR.DataAccess.Models;

public class Solve
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public SolveType SolveType { get; set; } = SolveType.TwoHands;

    public int CubeId { get; set; }

    [ForeignKey("CubeId")]
    public Cube? Cube { get; set; }

    [Required]
    public string Scramble { get; set; } = string.Empty;

    [Required]
    public DateTime LoggedDate { get; set; } = DateTime.Now;

    [Required]
    public TimeSpan SolveTime { get; set; }

    // TODO
    // Video
}
