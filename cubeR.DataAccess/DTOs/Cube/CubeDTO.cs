namespace cubeR.DataAccess
{
    public record CubeDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int SidesCount { get; set; }

        public int PiecesCount { get; set; }
    }
}
