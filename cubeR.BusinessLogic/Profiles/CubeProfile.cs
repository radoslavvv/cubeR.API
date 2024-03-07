using AutoMapper;
using cubeR.DataAccess.DTOs.Cube;
using cubeR.DataAccess.Models;

namespace cubeR.BusinessLogic.Profiles;
public class CubeProfile: Profile
{
    public CubeProfile()
    {
        CreateMap<Cube, CubeDTO>().ReverseMap();

        CreateMap<Cube, CubeCreateRequestDTO>().ReverseMap();

        CreateMap<Cube, CubeUpdateRequestDTO>().ReverseMap();
    }
}
