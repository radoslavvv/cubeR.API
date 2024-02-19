using cubeR.BusinessLogic;
using cubeR.BusinessLogic.Services.Contracts;
using cubeR.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace cubeR.API.Controllers
{
    [ApiController]
    [Route("api/cubes")]
    public class CubeController : ControllerBase
    {
        private readonly ICubeService _cubeService;

        public CubeController(ICubeService cubeService)
        {
            _cubeService = cubeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<CubeDTO> cubeDTOs = await _cubeService.GetAllCubesAsync();
            return Ok(cubeDTOs);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            CubeDTO? cubeDTO = await _cubeService.GetCubeByIdAsync(id);

            if (cubeDTO is null)
            {
                return NotFound();
            }

            return Ok(cubeDTO);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CubeCreateRequestDTO cubeCreateRequestDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CubeDTO createdCube = await _cubeService.CreateCubeAsync(cubeCreateRequestDTO);

            return CreatedAtAction(nameof(GetById), new { id = createdCube.Id }, createdCube);
        }

        [HttpPut("update/{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CubeUpdateRequestDTO cubeUpdateRequestDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CubeDTO? updatedCube = await _cubeService.UpdateCubeAsync(id, cubeUpdateRequestDTO);

            if (updatedCube is null)
            {
                return NotFound();
            }

            return Ok(updatedCube);
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            CubeDTO? cubeModel = await _cubeService.DeleteCubeAsync(id);

            if (cubeModel is null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
