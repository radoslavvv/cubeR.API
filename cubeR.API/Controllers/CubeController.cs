using AutoMapper;
using cubeR.DataAccess.DTOs.Cube;
using cubeR.DataAccess.Models;
using cubeR.DataAccess.Repositories.Contracts;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace cubeR.API.Controllers;

[ApiController]
[Route("api/cubes")]
public class CubeController : ControllerBase
{
    private readonly ICubeRepository _repository;
    private readonly IMapper _mapper;

    public CubeController(ICubeRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        IEnumerable<Cube> cubes = await _repository.GetCubesAsync();

        return Ok(_mapper.Map<IEnumerable<CubeDTO>>(cubes));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        Cube? cube = await _repository.GetCubeByIdAsync(id);

        if (cube is null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<CubeDTO>(cube));
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CubeCreateRequestDTO cubeCreateRequestDTO,
        [FromServices] IValidator<CubeCreateRequestDTO> validator)
    {
        ValidationResult validationResult = validator.Validate(cubeCreateRequestDTO);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        Cube createdCube = await _repository.CreateCubeAsync(_mapper.Map<Cube>(cubeCreateRequestDTO));

        return CreatedAtAction(nameof(GetById), new { id = createdCube.Id }, _mapper.Map<CubeDTO>(createdCube));
    }

    [HttpPut("update/{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CubeUpdateRequestDTO cubeUpdateRequestDTO,
        [FromServices] IValidator<CubeUpdateRequestDTO> validator)
    {
        ValidationResult validationResult = validator.Validate(cubeUpdateRequestDTO);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        Cube? updatedCube = await _repository.UpdateCubeAsync(id, cubeUpdateRequestDTO);

        if (updatedCube is null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<CubeDTO>(updatedCube));
    }

    [HttpDelete("delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        Cube? cubeModel = await _repository.DeleteCubeAsync(id);

        if (cubeModel is null)
        {
            return NotFound();
        }

        return NoContent();
    }
}