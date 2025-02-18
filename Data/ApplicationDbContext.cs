using FIRSTBACK.Instituciones;
using FIRSTBACK.Oportunidades;
using Institutions_Opportunity.Models;
using Microsoft.EntityFrameworkCore;

namespace FIRSTBACK.Data
{
    public class ApplicationDbContext : DbContext
    {
     //   internal object InstitutionOpportunity;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        public DbSet<Institucion> Instituciones { get; set; }
        public DbSet<InstitutionOpportunity> InstitutionOpportunities { get; set; }
        public object Oportunidades { get; internal set; }
    }
}