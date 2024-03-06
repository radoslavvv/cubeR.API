using cubeR.DataAccess.DTOs.Solve;
using cubeR.BusinessLogic.Mappers;
using cubeR.DataAccess.Enums;
using cubeR.DataAccess.Models;
using cubeR.DataAccess.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using FluentValidation.Results;

namespace cubeR.API.Controllers;

[ApiController]
[Route("api/solve")]
public class SolveController : ControllerBase
{
    private readonly ISolveRepository _solveRepository;
    private readonly ICubeRepository _cubeRepository;

    public SolveController(ISolveRepository solveRepository, ICubeRepository cubeRepository)
    {
        _solveRepository = solveRepository;
        _cubeRepository = cubeRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        List<Solve> solves = await _solveRepository.GetAllSolvesAsync();
        List<SolveDTO> solvesDTOs = solves.Select(s => s.ToSolveDTO()).ToList();

        return Ok(solvesDTOs);
    }

    [HttpGet("last/{count:int}")]
    public async Task<IActionResult> GetLastNSolves([FromRoute] int count)
    {
        List<Solve> solves = await _solveRepository.GetLastNSolvesAsync(count);
        List<SolveDTO> solvesDTOs = solves.Select(s => s.ToSolveDTO()).ToList();

        return Ok(solvesDTOs);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        Solve? solve = await _solveRepository.GetSolveByIdAsync(id);

        if (solve is null)
        {
            return NotFound();
        }

        return Ok(solve.ToSolveDTO());
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
            return NotFound("Cube not found.");
        }

        //if (!Enum.TryParse(solveCreateRequestDTO.SolveType, out SolveType solveTypeParsed))
        //{
        //    return BadRequest("Solve Type is not valid.");
        //}

        //if (!TimeSpan.TryParse(solveCreateRequestDTO.SolveTime, out TimeSpan solveTimeParsed))
        //{
        //    return BadRequest("Solve Time is not valid.");
        //}

        Solve createdSolve = await _solveRepository.CreateSolveAsync(solveCreateRequestDTO.FromCreateRequestDTOToSolve());

        return CreatedAtAction(nameof(GetById), new { id = createdSolve.Id }, createdSolve.ToSolveDTO());
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

