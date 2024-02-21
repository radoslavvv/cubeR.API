namespace cubeR.DataAccess.DTOs.Cube;

//public record CubeDTO
//{
//    public int Id { get; set; }

//    public string Name { get; set; } = string.Empty;

//    public int SidesCount { get; set; }

//    public int PiecesCount { get; set; }
//}

public record CubeDTO(int Id, string Name, int SidesCount, int PiecesCount);