using cubeR.DataAccess.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cubeR.DataAccess.Models;

public class Cube
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(250)]
    public string Name { get; set; } = string.Empty;

    [Required]
    public int SidesCount { get; set; }

    [Required]
    public int PiecesCount { get; set; }

    [Required]
    public double Weight { get; set; }

    [Required]
    public CubeDifficultyLevel DifficultyLevel { get; set; }

    [Required]
    public int ReleaseYear { get; set; }

    [Required]
    [MaxLength(250)]
    public string Material { get; set; } = string.Empty;

    // TODO
    //public string CubeImage { get; set; }

    public ICollection<Solve> Solves { get; set; } = new List<Solve>();
}

