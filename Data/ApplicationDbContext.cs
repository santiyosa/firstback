using FIRSTBACK.Instituciones;
using FIRSTBACK.Oportunidades;
using Microsoft.EntityFrameworkCore;

namespace BackendProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Oportunidad> Oportunidades { get; set; }
        public DbSet<Institucion> Instituciones { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Oportunidad>()
                .HasOne(o => o.Institucion)
                .WithMany() // Si una institución tiene muchas oportunidades, usa `.WithMany(i => i.Oportunidades)`
                .HasForeignKey(o => o.id_institucion)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}