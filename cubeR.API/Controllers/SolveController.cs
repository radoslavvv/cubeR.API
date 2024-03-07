using cubeR.DataAccess.DTOs.Solve;
using cubeR.DataAccess.Models;
using cubeR.DataAccess.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using FluentValidation.Results;
using AutoMapper;

namespace cubeR.API.Controllers;

[ApiController]
[Route("api/solves")]
public class SolveController : ControllerBase
{
    private readonly ISolveRepository _solveRepository;
    private readonly ICubeRepository _cubeRepository;
    private readonly IMapper _mapper;

    public SolveController(ISolveRepository solveRepository, ICubeRepository cubeRepository, IMapper mapper)
    {
        _solveRepository = solveRepository;
        _cubeRepository = cubeRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        IEnumerable<Solve> solves = await _solveRepository.GetSolvesAsync();

        return Ok(_mapper.Map<IEnumerable<SolveDTO>>(solves));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        Solve? solve = await _solveRepository.GetSolveByIdAsync(id);

        if (solve is null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<SolveDTO>(solve));
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] SolveCreateRequestDTO solveCreateRequestDTO,
        [FromServices] IValidator<SolveCreateRequestDTO> validator)
    {
        ValidationResult validationResult = validator.Validate(solveCreateRequestDTO);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        Cube? cube = await _cubeRepository.GetCubeByIdAsync(solveCreateRequestDTO.CubeId);

        if (cube is null)
        {
            return NotFound();
        }

        Solve createdSolve = await _solveRepository.CreateSolveAsync(_mapper.Map<Solve>(solveCreateRequestDTO));

        return CreatedAtAction(nameof(GetById), new { id = createdSolve.Id }, _mapper.Map<SolveDTO>(createdSolve));
    }

    [HttpDelete("delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        Solve? deletedSolve = await _solveRepository.DeleteSolveAsync(id);

        if (deletedSolve is null)
        {
            return NotFound();
        }

        return NoContent();
    }
}

