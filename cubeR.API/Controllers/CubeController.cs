using cubeR.BusinessLogic;
using cubeR.BusinessLogic.Services.Contracts;
using cubeR.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace cubeR.API.Controllers
{
    [ApiController]
    [Route("api/cubes")]
    public class CubeController:ControllerBase
    {
        private readonly ICubeRepository _repository;

        private readonly ICubeService _cubeService;

        public CubeController(ICubeRepository repository, ICubeService cubeService)
        {
            _repository = repository;
            _cubeService = cubeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<CubeDTO> cubeDTOs = await _cubeService.GetCubesAsync();

            return Ok(cubeDTOs);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            CubeDTO? cubeDTO = await _cubeService.GetCubeByIdAsync(id);

            if(cubeDTO == null)
            {
                return NotFound();
            }

            return Ok(cubeDTO);
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

        [HttpPut("update/{id:int}")]
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

        [HttpDelete("delete/{id:int}")]
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
