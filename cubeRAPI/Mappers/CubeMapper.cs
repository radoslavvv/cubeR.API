using cubeR.DataAccess;

namespace cubeR.API.Mappers
{
    public static class CubeMapper
    {
        public static CubeDTO ToCubeDTO(this Cube cubeModel)
        {
            return new CubeDTO
            {
                Id = cubeModel.Id,
                Name = cubeModel.Name,
                PiecesCount = cubeModel.PiecesCount,
                SidesCount = cubeModel.SidesCount,
            };
        }

        public static Cube FromCreateRequestDTOToCube(this CubeCreateRequestDTO cubeCreateRequestDTO)
        {
            return new Cube
            {
                Name = cubeCreateRequestDTO.Name,
                PiecesCount = cubeCreateRequestDTO.PiecesCount,
                SidesCount = cubeCreateRequestDTO.SidesCount,
            };
        }
    }
}
