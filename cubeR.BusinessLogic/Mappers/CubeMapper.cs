using cubeR.DataAccess.DTOs.Cube;
using cubeR.DataAccess.Models;

namespace cubeR.BusinessLogic.Mappers;

public static class CubeMapper
{
    public static CubeDTO ToCubeDTO(this Cube cubeModel)
    {
        return new CubeDTO(cubeModel.Id, cubeModel.Name, cubeModel.PiecesCount, cubeModel.SidesCount);
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

