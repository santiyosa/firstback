using AutoMapper;
using firstback.Oportunidades;
using Microsoft.AspNetCore.Mvc;

namespace FIRSTBACK.Oportunidades
{
    [Route("api/[controller]")]
    [ApiController]
    public class OportunidadController : ControllerBase
    {
        private readonly IOportunidadService _oportunidadService;
                private readonly IMapper _mapper;

        public OportunidadController(IOportunidadService oportunidadService, IMapper mapper)
        {
            _oportunidadService = oportunidadService;
                        _mapper = mapper;
        }

        // GET: api/Oportunidad
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OportunidadesInstitucionesDTO>>> GetAll()
        {
            /* return Ok(await _oportunidadService.GetAllAsync()); */
                var oportunidades = await _oportunidadService.GetAllAsync();
    return Ok(oportunidades);
        }

        // GET: api/Oportunidad/id
        [HttpGet("{id}")]
        public async Task<ActionResult<OportunidadesInstitucionesDTO>> Get(int id)
        {
            var product = await _oportunidadService.GetByIdAsync(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        // POST: api/
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Oportunidad oportunidad)
        {
            await _oportunidadService.CreateAsync(oportunidad);
            return CreatedAtAction(nameof(Get), new { id = oportunidad.id }, oportunidad);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Oportunidad oportunidad)
        {
            var existingOportunidad = await _oportunidadService.GetByIdAsync(id);
            if (existingOportunidad == null)
                return NotFound();
            oportunidad.id = id;
            await _oportunidadService.UpdateAsync(id, oportunidad);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existingOportunidad = await _oportunidadService.GetByIdAsync(id);
            if (existingOportunidad == null)
                return NotFound();
            await _oportunidadService.DeleteAsync(id);
            return NoContent();
        }
    }
}