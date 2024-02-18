using cubeR.API.Mappers;
using cubeR.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace cubeR.API.Controllers
{
    [ApiController]
    [Route("api/cubes")]
    public class CubeController:ControllerBase
    {
        private readonly ICubeRepository _repository;
        public CubeController(ICubeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            List<Cube> cubes = await _repository.GetAllCubesAsync();

            IEnumerable<CubeDTO> cubeDTOs = cubes.Select(c => c.ToCubeDTO());

            return Ok(cubeDTOs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Cube? cube = await _repository.GetCubeByIdAsync(id);

            if(cube == null)
            {
                return NotFound();
            }

            return Ok(cube.ToCubeDTO());
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CubeCreateRequestDTO cubeCreateRequestDTO)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Cube cubeModel = cubeCreateRequestDTO.FromCreateRequestDTOToCube();

            Cube createdCube = await _repository.CreateCubeAsync(cubeModel);

            return CreatedAtAction(nameof(GetById), new { id = createdCube.Id }, createdCube.ToCubeDTO());
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CubeUpdateRequestDTO cubeUpdateRequestDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Cube? cubeModel = await _repository.UpdateCubeAsync(id, cubeUpdateRequestDTO);

            if(cubeModel == null)
            {
                return NotFound();
            }

            return Ok(cubeModel.ToCubeDTO());
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            Cube? cubeModel = await _repository.DeleteCubeAsync(id);

            if(cubeModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
