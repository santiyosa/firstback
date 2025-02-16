using FIRSTBACK.InstitucionesBootcamps;
using Microsoft.EntityFrameworkCore;

namespace BackendProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
       base(options)
        {

        }

        public DbSet<InstitucionBootcamp> InstitucionBootcamps { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InstitucionBootcamp>()
                .HasKey(bt => new { bt.Id_Institucion, bt.Id_Bootcamp }); // Clave compuesta
        }
    }
}