using cubeR.BusinessLogic.Services.Contracts;
using cubeR.DataAccess;
using cubeR.DataAccess.DTOs.Cube;
using cubeR.DataAccess.DTOs.Solve;
using cubeR.DataAccess.Enums;
using Microsoft.AspNetCore.Mvc;

namespace cubeR.API.Controllers;

[Route("api/solve")]
[ApiController]
public class SolveController : ControllerBase
{
    private readonly ISolveService _solveService;
    private readonly ICubeService _cubeService;

    public SolveController(ISolveService solveService, ICubeService cubeService)
    {
        _solveService = solveService;
        _cubeService = cubeService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        List<SolveDTO> solvesDTOs = await _solveService.GetAllSolvesAsync();
        return Ok(solvesDTOs);
    }

    [HttpGet("last/{count:int}")]
    public async Task<IActionResult> GetLastNSolves([FromRoute] int count)
    {
        List<SolveDTO> solvesDTOs = await _solveService.GetLastNSolvesAsync(count);
        return Ok(solvesDTOs);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        SolveDTO? solveDTO = await _solveService.GetSolveByIdAsync(id);

        if (solveDTO is null)
        {
            return NotFound();
        }

        return Ok(solveDTO);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] SolveCreateRequestDTO solveCreateRequestDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        CubeDTO? cube = await _cubeService.GetCubeByIdAsync(solveCreateRequestDTO.CubeId);

        if (cube is null)
        {
            return NotFound("Cube not found.");
        }

        if (!Enum.TryParse(solveCreateRequestDTO.SolveType, out SolveType solveTypeParsed))
        {
            return BadRequest("Solve Type is not valid.");
        }

        if (!TimeSpan.TryParse(solveCreateRequestDTO.SolveTime, out TimeSpan solveTimeParsed))
        {
            return BadRequest("Solve Time is not valid.");
        }

        SolveDTO createdSolveDTO = await _solveService.CreateSolveAsync(solveCreateRequestDTO);

        return CreatedAtAction(nameof(GetById), new { id = createdSolveDTO.Id }, createdSolveDTO);
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        SolveDTO? deletedSolve = await _solveService.DeleteSolveAsync(id);

        if (deletedSolve is null)
        {
            return NotFound();
        }

        return NoContent();
    }
}

