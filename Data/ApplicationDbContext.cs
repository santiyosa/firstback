using FIRSTBACK.Instituciones;
using FIRSTBACK.Tematicas;
using Microsoft.EntityFrameworkCore;
using firstback.roles;
using firstback.categorias;
using firstback.user;

namespace BackendProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Roles> Roles { get; set; }
        public DbSet<Tematica> Tematicas { get; set; }
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Institucion> Instituciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role) 
                .WithMany(r => r.Users); 
        }
    }
}