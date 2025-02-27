using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebbAPI.DTOs;
using WebbAPI.Repositorys.Contracts;

namespace WebbAPI.Controllers
{
    [Route("api/[controller]")]
    public class BasicModelController : ControllerBase
    {
        private BasicModelDTO? basicModel;
        IEnumerable<BasicModelDTO>? basicModels;

        private readonly IBasicModel _basicModelRepository;
        public BasicModelController(IBasicModel basicModelRepository)
        {
            _basicModelRepository = basicModelRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BasicModelDTO>> GetModel(int id)
        {
            basicModel = await _basicModelRepository.GetBasicModel(id);

            if (basicModel == null)
            {
                return NotFound();
            }

            return basicModel;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BasicModelDTO>>> GetModels()
        {
            basicModels = await _basicModelRepository.GetAllBasicModelsAsync();

            return Ok(basicModels);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModel(int id)
        {
            await _basicModelRepository.DeleteBasicModelAsync(id);

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<BasicModelDTO>> CreateModel([FromBody] BasicModelDTO basicModelDTO)
        {
            try
            {
                var newModel = await _basicModelRepository.AddBasicModelAsync(basicModelDTO);

                if (newModel == null)
                {
                    return NoContent();
                }

                BasicModelDTO newModelDto = new BasicModelDTO
                {
                    Id = newModel.Id,
                    Name = newModel.Name
                };

                return CreatedAtAction(nameof(GetModel), new { id = newModelDto.Id }, newModelDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateModel(int id, [FromBody] BasicModelDTO basicModelDTO)
        {
            if (id != basicModelDTO.Id)
            {
                return BadRequest();
            }
            try
            {
                await _basicModelRepository.UpdateModel(basicModelDTO);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
