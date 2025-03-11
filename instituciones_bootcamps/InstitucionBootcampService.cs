using Microsoft.EntityFrameworkCore;
using BackendProject.Data;

namespace firstback.InstitucionesBootcamps
{
    public class InstitucionBootcampService : IInstitucionBootcampService
    {
        private readonly ApplicationDbContext _context;

        public InstitucionBootcampService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<InstitucionBootcamp>> GetAllAsync()
        {
            return await _context.InstitucionBootcamps
            .Include(ib => ib.Institucion)
            .Include(ib => ib.Bootcamp)
            .ToListAsync();
        }

        public async Task<InstitucionBootcamp?> GetByIdAsync(int idInstitucion, int idBootcamp)
        {
            return await _context.InstitucionBootcamps
            .Include(ib => ib.Institucion)
            .Include(ib => ib.Bootcamp)
            .FirstOrDefaultAsync(ib => ib.Id_Institucion == idInstitucion && ib.Id_Bootcamp == idBootcamp);
        }

        public async Task<InstitucionBootcamp> CreateAsync(InstitucionBootcampDto institucionBootcampDto)
        {
            var institucionBootcamp = InstitucionBootcampMapper.MapToEntity(institucionBootcampDto);

            _context.InstitucionBootcamps.Add(institucionBootcamp);
            await _context.SaveChangesAsync();

            return await GetByIdAsync(institucionBootcamp.Id_Institucion, institucionBootcamp.Id_Bootcamp) ?? institucionBootcamp;
        }

        public async Task<bool> UpdateAsync(int idInstitucion, int idBootcamp, InstitucionBootcampDto institucionBootcampDto)
        {
            var institucionBootcamp = await GetByIdAsync(idInstitucion, idBootcamp);
            if (institucionBootcamp == null) return false;

            institucionBootcamp.Id_Institucion = institucionBootcampDto.IdInstitucion;
            institucionBootcamp.Id_Bootcamp = institucionBootcampDto.IdBootcamp;

            _context.Entry(institucionBootcamp).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int idInstitucion, int idBootcamp)
        {
            var institucionBootcamp = await GetByIdAsync(idInstitucion, idBootcamp);
            if (institucionBootcamp == null) return false;

            _context.InstitucionBootcamps.Remove(institucionBootcamp);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}