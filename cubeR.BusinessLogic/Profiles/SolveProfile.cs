using AutoMapper;
using cubeR.DataAccess.DTOs.Solve;
using cubeR.DataAccess.Models;

namespace cubeR.BusinessLogic.Profiles;
public class SolveProfile : Profile
{
    public SolveProfile()
    {
        CreateMap<Solve, SolveDTO>().ReverseMap();

        CreateMap<Solve, SolveCreateRequestDTO>().ReverseMap();
    }
}
