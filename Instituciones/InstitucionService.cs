using FIRSTBACK.Data;
using Microsoft.EntityFrameworkCore;

namespace FIRSTBACK.Instituciones
{
    public class InstitucionService : IInstitucionService
    {
        private readonly ApplicationDbContext _context;

        public InstitucionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Institucion>> GetAllAsync()
        {
            return await _context.Instituciones.ToListAsync();
        }

        public async Task<Institucion?> GetByIdAsync(int id)
        {
            return await _context.Instituciones.FindAsync(id);
        }

        public async Task CreateAsync(Institucion institucion)
        {
            _context.Instituciones.Add(institucion);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, Institucion institucion)
        {
            var existingInstitucion = await _context.Instituciones.FindAsync(id);
            if (existingInstitucion != null)
            {
                existingInstitucion.nombre = institucion.nombre;
                existingInstitucion.ubicacion = institucion.ubicacion;
                existingInstitucion.url_generalidades = institucion.url_generalidades;
                existingInstitucion.url_oferta_academica = institucion.url_oferta_academica;
                existingInstitucion.url_bienestar = institucion.url_bienestar;
                existingInstitucion.url_admision = institucion.url_admision;
 
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var institucion = await _context.Instituciones.FindAsync(id);
            if (institucion != null)
            {
                _context.Instituciones.Remove(institucion);
                await _context.SaveChangesAsync();
            }
        }

    }
}