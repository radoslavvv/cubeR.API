using cubeR.API.Mappers;
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


        public SolveController(ISolveRepository repository, ICubeRepository cubeRepository)
        {
            _solveRepository = repository;
            _cubeRepository = cubeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Solve> solves = await _solveRepository.GetAllAsync();
            IEnumerable<SolveDTO> solvesDTOs = solves.Select(s => s.ToSolveDTO());

            return Ok(solvesDTOs);
        }

        [HttpGet("last/{count:int}")]
        public async Task<IActionResult> GetLastNSolves([FromRoute] int count)
        {
            List<Solve> solves = await _solveRepository.GetLastNSolvesAsync(count);
            IEnumerable<SolveDTO> solvesDTOs = solves.Select(s => s.ToSolveDTO());

            return Ok(solvesDTOs);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            Solve? solve = await _solveRepository.GetByIdAsync(id);

            if(solve == null)
            {
                return NotFound();
            }

            return Ok(solve);
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

            Solve solveModel = solveCreateRequestDTO.FromCreateRequestDTOToSolve();

            Solve createdSolve = await _solveRepository.CreateAsync(solveModel);

            return CreatedAtAction(nameof(GetById), new { id = createdSolve.Id }, createdSolve.ToSolveDTO());
        }
    }
}
