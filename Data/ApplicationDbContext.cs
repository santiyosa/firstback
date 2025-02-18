using Microsoft.EntityFrameworkCore;
using firstback.roles;

namespace BackendProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
       base(options)
        { }

        public DbSet<Roles> Roles { get; set; }
    }
}