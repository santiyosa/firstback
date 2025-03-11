using Microsoft.AspNetCore.Mvc;

namespace firstback.InstitucionesBootcamps
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstitucionBootcampController : ControllerBase
    {
        private readonly IInstitucionBootcampService _service;

        public InstitucionBootcampController(IInstitucionBootcampService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InstitucionBootcamp>>> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{idInstitucion}/{idBootcamp}")]
        public async Task<ActionResult<InstitucionBootcamp>> GetById(int idInstitucion, int idBootcamp)
        {
            var result = await _service.GetByIdAsync(idInstitucion, idBootcamp);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<InstitucionBootcamp>> Create([FromBody] InstitucionBootcampDto institucionBootcampDto)
        {
            var created = await _service.CreateAsync(institucionBootcampDto);
            return CreatedAtAction(nameof(GetById), new { idInstitucion = created.Id_Institucion, idBootcamp = created.Id_Bootcamp }, created);
        }

        [HttpPut("{idInstitucion}/{idBootcamp}")]
        public async Task<IActionResult> Update(int idInstitucion, int idBootcamp, [FromBody] InstitucionBootcampDto institucionBootcampDto)
        {
            var updated = await _service.UpdateAsync(idInstitucion, idBootcamp, institucionBootcampDto);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{idInstitucion}/{idBootcamp}")]
        public async Task<IActionResult> Delete(int idInstitucion, int idBootcamp)
        {
            var deleted = await _service.DeleteAsync(idInstitucion, idBootcamp);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}