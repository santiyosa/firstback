using BackendProject.Models;
using FIRSTBACK.Instituciones;
using FIRSTBACK.Oportunidades;
using Microsoft.EntityFrameworkCore;
using Users_Opportunities.Models;

namespace BackendProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
       base(options)
        {
            public DbSet<Oportunidad> Oportunidades { get; set; }
            public DbSet<Institucion> Instituciones { get; set; }
            public DbSet<User> Users { get; set; }
            public DbSet<UserOpportunity> UsersOpportunities { get; set; }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserOpportunity>()
                .HasKey(uo => new { uo.userId, uo.opportunityId });

          /*  modelBuilder.Entity<UserOpportunity>()
                .HasOne(uo => uo.User)
                .WithMany(uo => uo.userId)
                .HasForeignKey(uo => uo.UserId)
                .OnDelete(DeleteBehavior.Restrict); // Recomendado: Evita borrados en cascada
 // Recomendado: Evita borrados en cascada*/
 
        }
    }
}