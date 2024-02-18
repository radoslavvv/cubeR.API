using cubeR.BusinessLogic.Services.Contracts;
using cubeR.DataAccess;
using cubeR.DataAccess.Enums;
using Microsoft.AspNetCore.Mvc;

namespace cubeRAPI.Controllers
{
    [Route("api/solve")]
    [ApiController]
    public class SolveController : ControllerBase
    {
        private readonly ISolveRepository _solveRepository;
        private readonly ICubeRepository _cubeRepository;

        private readonly ISolveService _solveService;

        public SolveController(ISolveRepository repository, ICubeRepository cubeRepository, ISolveService solveService)
        {
            _solveRepository = repository;
            _cubeRepository = cubeRepository;
            _solveService = solveService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<SolveDTO> solvesDTOs = await _solveService.GetAllSolvesAsync();
            return Ok(solvesDTOs);
        }

        [HttpGet("last/{count:int}")]
        public async Task<IActionResult> GetLastNSolves([FromRoute] int count)
        {
            IEnumerable<SolveDTO> solvesDTOs = await _solveService.GetLastNSolvesAsync(count);
            return Ok(solvesDTOs);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            SolveDTO? solveDTO = await _solveService.GetSolveByIdAsync(id);

            if(solveDTO == null)
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

            Cube? cube = await _cubeRepository.GetCubeByIdAsync(solveCreateRequestDTO.CubeId);

            if(cube == null)
            {
                return NotFound("Cube not found.");
            }

            if(!Enum.TryParse(solveCreateRequestDTO.SolveType, out SolveType solveTypeParsed))
            {
                return BadRequest("Solve Type is not valid.");
            }

            if(!TimeSpan.TryParse(solveCreateRequestDTO.SolveTime, out TimeSpan solveTimeParsed))
            {
                return BadRequest("Solve Time is not valid.");
            }

            SolveDTO createdSolveDTO = await _solveService.CreateSolveAsync(solveCreateRequestDTO);

            return CreatedAtAction(nameof(GetById), new { id = createdSolveDTO.Id }, createdSolveDTO);
        }
    }
}
