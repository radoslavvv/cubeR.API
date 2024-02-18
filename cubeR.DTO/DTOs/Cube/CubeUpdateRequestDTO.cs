namespace cubeR.DTOs
{
    public class CubeUpdateRequestDTO
    {
        public string Name { get; set; } = string.Empty;

        public int SidesCount { get; set; }

        public int PiecesCount { get; set; }
    }
}
