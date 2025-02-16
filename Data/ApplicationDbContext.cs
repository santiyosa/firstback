using FIRSTBACK.Tematicas;
using Microsoft.EntityFrameworkCore;

namespace BackendProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
       base(options)
        {
        }

        public DbSet<BootcampTematica> BootcampTematicas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BootcampTematica>()
                .HasKey(bt => new { bt.IdBootcamp, bt.IdTematica }); // Clave compuesta
        }
    }
}