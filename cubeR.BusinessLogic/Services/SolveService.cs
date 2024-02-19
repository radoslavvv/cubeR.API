using cubeR.BusinessLogic.Services.Contracts;
using cubeR.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cubeR.BusinessLogic.Services;
public class SolveService: ISolveService
{
    private readonly ISolveRepository _solveRepository;

    public SolveService(ISolveRepository solveRepository)
    {
        _solveRepository = solveRepository;
    }

    public async Task<List<SolveDTO>> GetAllSolvesAsync()
    {
        List<Solve> solves = await _solveRepository.GetAllSolvesAsync();
        return solves.Select(s => s.ToSolveDTO()).ToList();
    }

    public async Task<List<SolveDTO>> GetLastNSolvesAsync(int count)
    {
        List<Solve> solves = await _solveRepository.GetLastNSolvesAsync(count);
        return solves.Select(s => s.ToSolveDTO()).ToList();
    }

    public async Task<SolveDTO?> GetSolveByIdAsync(int id)
    {
        Solve? solve = await _solveRepository.GetSolveByIdAsync(id);
        return solve?.ToSolveDTO();
    }

    public async Task<SolveDTO> CreateSolveAsync(SolveCreateRequestDTO solveCreateRequestDTO)
    {
        Solve solveModel = solveCreateRequestDTO.FromCreateRequestDTOToSolve();
        Solve createdSolve = await _solveRepository.CreateSolveAsync(solveModel);

        return createdSolve.ToSolveDTO();
    }

    public async Task<SolveDTO?> DeleteSolveAsync(int id)
    {
        Solve? deletedSolve = await _solveRepository.DeleteSolveAsync(id);
        return deletedSolve?.ToSolveDTO();
    }
}
