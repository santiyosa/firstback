using Microsoft.EntityFrameworkCore;
using firstback.categorias;

namespace BackendProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
       base(options)
        { }
        public DbSet<Categorias> Categorias { get; set; }

    }
}