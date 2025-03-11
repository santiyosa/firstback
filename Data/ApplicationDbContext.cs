using Microsoft.EntityFrameworkCore;
using firstback.Instituciones;
using firstback.InstitucionesBootcamps;
using firstback.roles;
using firstback.categorias;
using firstback.user;
using firstback.bootcamps;
using firstback.BootcampsTematicas;
using firstback.Oportunidades;
using firstback.tematicas;
using firstback.UsersOpportunities;

namespace BackendProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Roles> Roles { get; set; }
        public DbSet<Tematica> Tematicas { get; set; }
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<Oportunidad> Oportunidades { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Institucion> Instituciones { get; set; }
        public DbSet<Bootcamp> Bootcamps { get; set; }
        public DbSet<BootcampTematica> BootcampTematicas { get; set; }
        public DbSet<InstitucionBootcamp> InstitucionBootcamps { get; internal set; }
        public DbSet<UsersOpportunities> UsersOpportunities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users);

            modelBuilder.Entity<Bootcamp>()
                .HasOne(b => b.Institucion)
                .WithMany(t => t.bootcamps);

            modelBuilder.Entity<BootcampTematica>()
            .HasKey(bt => new { bt.IdBootcamp, bt.IdTematica });

            modelBuilder.Entity<InstitucionBootcamp>()
                .HasKey(bt => new { bt.Id_Institucion, bt.Id_Bootcamp });

            modelBuilder.Entity<UsersOpportunities>()
            .HasKey(uo => new { uo.IdUser, uo.IdOpportunity });
        }
    }
}