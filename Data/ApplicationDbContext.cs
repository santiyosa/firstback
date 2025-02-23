using FIRSTBACK.Tematicas;
using Microsoft.EntityFrameworkCore;
using firstback.categorias;

namespace firstback.user
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Tematica> Tematicas { get; set; }
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
