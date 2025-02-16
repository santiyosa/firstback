using FIRSTBACK.Instituciones;
using FIRSTBACK.Oportunidades;
using FIRSTBACK.Instituciones;
using Microsoft.EntityFrameworkCore;

namespace FIRSTBACK.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        public DbSet<Institucion> Instituciones { get; set; }

    }
}