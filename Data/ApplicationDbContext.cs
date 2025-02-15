using FIRSTBACK.Tematicas;
using Microsoft.EntityFrameworkCore;

namespace BackendProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Tematica> Tematicas { get; set; }
    }

    public class TematicaRepository : ITematicaService
    {
        private readonly ApplicationDbContext _context;

        public TematicaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tematica>> GetAllAsync()
            => await _context.Tematicas.ToListAsync();

        public async Task<Tematica?> GetByIdAsync(int id)
            => await _context.Tematicas.FindAsync(id);

        public async Task CreateAsync(Tematica tematica)
        {
            await _context.Tematicas.AddAsync(tematica);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, Tematica tematica)
        {
            var existing = await _context.Tematicas.FindAsync(id);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(tematica);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var tematica = await _context.Tematicas.FindAsync(id);
            if (tematica != null)
            {
                _context.Tematicas.Remove(tematica);
                await _context.SaveChangesAsync();
            }
        }
    }

}
