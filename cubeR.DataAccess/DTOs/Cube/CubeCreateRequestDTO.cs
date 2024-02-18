using System.ComponentModel.DataAnnotations;

namespace cubeR.DataAccess
{
    public record CubeCreateRequestDTO
    {
        [Required]
        [MinLength(1, ErrorMessage = "Name cannot be empty!")]
        [MaxLength(250, ErrorMessage = "Name cannot be more than 250 characters!")]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int SidesCount { get; set; }

        [Required]
        public int PiecesCount { get; set; }

        public Cube FromCreateRequestDTOToCube()
        {
            throw new NotImplementedException();
        }
    }
}
