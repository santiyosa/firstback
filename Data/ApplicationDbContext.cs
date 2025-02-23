using FIRSTBACK.Instituciones;
using FIRSTBACK.Tematicas;
using Microsoft.EntityFrameworkCore;
using firstback.categorias;
using firstback.user;

namespace FIRSTBACK.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Tematica> Tematicas { get; set; }
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Institucion> Instituciones { get; set; }
    }
}
