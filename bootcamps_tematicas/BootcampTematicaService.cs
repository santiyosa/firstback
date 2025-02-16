using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BackendProject.Data;
using FIRSTBACK.Tematicas;
using FIRSTBACK.Dtos;

public class BootcampTematicaService : IBootcampTematicaService
{
    private readonly ApplicationDbContext _context;

    public BootcampTematicaService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<BootcampTematica>> GetAllAsync()
    {
        return await _context.BootcampTematicas
            .Include(bt => bt.Bootcamp)
            .Include(bt => bt.Tematica)
            .ToListAsync();
    }

    public async Task<BootcampTematica?> GetByIdAsync(int idBootcamp, int idTematica)
    {
        return await _context.BootcampTematicas
            .Include(bt => bt.Bootcamp)
            .Include(bt => bt.Tematica)
            .FirstOrDefaultAsync(bt => bt.IdBootcamp == idBootcamp && bt.IdTematica == idTematica);
    }

    public async Task<BootcampTematica> CreateAsync(BootcampTematicaDto bootcampTematicaDto)
    {
        var bootcampTematica = BootcampTematicaMapper.MapToEntity(bootcampTematicaDto);

        _context.BootcampTematicas.Add(bootcampTematica);
        await _context.SaveChangesAsync();

        return await GetByIdAsync(bootcampTematica.IdBootcamp, bootcampTematica.IdTematica) ?? bootcampTematica;
    }

    public async Task<bool> UpdateAsync(int idBootcamp, int idTematica, BootcampTematicaDto bootcampTematicaDto)
    {
        var bootcampTematica = await GetByIdAsync(idBootcamp, idTematica);
        if (bootcampTematica == null) return false;

        bootcampTematica.IdBootcamp = bootcampTematicaDto.IdBootcamp;
        bootcampTematica.IdTematica = bootcampTematicaDto.IdTematica;

        _context.Entry(bootcampTematica).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int idBootcamp, int idTematica)
    {
        var bootcampTematica = await GetByIdAsync(idBootcamp, idTematica);
        if (bootcampTematica == null) return false;

        _context.BootcampTematicas.Remove(bootcampTematica);
        await _context.SaveChangesAsync();

        return true;
    }
}
