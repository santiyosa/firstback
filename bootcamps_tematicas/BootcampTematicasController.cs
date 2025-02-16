using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using FIRSTBACK.Dtos;

[Route("api/[controller]")]
[ApiController]
public class BootcampTematicasController : ControllerBase
{
    private readonly IBootcampTematicaService _service;

    public BootcampTematicasController(IBootcampTematicaService service)
    {
        _service = service;
    }

    // GET: api/BootcampTematicas
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BootcampTematicaDto>>> GetAll()
    {
        var bootcampTematicas = await _service.GetAllAsync();
        return Ok(bootcampTematicas);
    }

    // GET: api/BootcampTematicas/{idBootcamp}/{idTematica}
    [HttpGet("{idBootcamp}/{idTematica}")]
    public async Task<ActionResult<BootcampTematicaDto>> GetById(int idBootcamp, int idTematica)
    {
        var bootcampTematica = await _service.GetByIdAsync(idBootcamp, idTematica);
        if (bootcampTematica == null) return NotFound("No se encontró la relación Bootcamp-Tematica.");
        return Ok(bootcampTematica);
    }

    // POST: api/BootcampTematicas
    [HttpPost]
    public async Task<ActionResult<BootcampTematicaDto>> Create([FromBody] BootcampTematicaDto bootcampTematicaDto)
    {
        var bootcampTematica = await _service.CreateAsync(bootcampTematicaDto);
        return CreatedAtAction(nameof(GetById), new { idBootcamp = bootcampTematica.IdBootcamp, idTematica = bootcampTematica.IdTematica }, bootcampTematica);
    }

    // PUT: api/BootcampTematicas/{idBootcamp}/{idTematica}
    [HttpPut("{idBootcamp}/{idTematica}")]
    public async Task<IActionResult> Update(int idBootcamp, int idTematica, [FromBody] BootcampTematicaDto bootcampTematicaDto)
    {
        var updated = await _service.UpdateAsync(idBootcamp, idTematica, bootcampTematicaDto);
        if (!updated) return NotFound("No se encontró la relación Bootcamp-Tematica.");
        return NoContent();
    }

    // DELETE: api/BootcampTematicas/{idBootcamp}/{idTematica}
    [HttpDelete("{idBootcamp}/{idTematica}")]
    public async Task<IActionResult> Delete(int idBootcamp, int idTematica)
    {
        var deleted = await _service.DeleteAsync(idBootcamp, idTematica);
        if (!deleted) return NotFound("No se encontró la relación Bootcamp-Tematica.");
        return NoContent();
    }
}
