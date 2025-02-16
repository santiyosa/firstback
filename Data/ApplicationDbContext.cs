using Microsoft.EntityFrameworkCore;
using Users_Opportunities.Models;
using Users_Opportunities.Models.Users_Opportunities.Models;

namespace BackendProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Opportunity> Opportunities { get; set; }
        public DbSet<UserOpportunity> UsersOpportunities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserOpportunity>()
                .HasKey(uo => new { uo.UserId, uo.OpportunityId });

            modelBuilder.Entity<UserOpportunity>()
                .HasOne(uo => uo.User)
                .WithMany(u => u.UserOpportunities)
                .HasForeignKey(uo => uo.UserId)
                .OnDelete(DeleteBehavior.Restrict); // Recomendado: Evita borrados en cascada

            modelBuilder.Entity<UserOpportunity>()
                .HasOne(uo => uo.Opportunity)
                .WithMany(o => o.UserOpportunities)
                .HasForeignKey(uo => uo.OpportunityId)
                .OnDelete(DeleteBehavior.Restrict); // Recomendado: Evita borrados en cascada
        }
    }
}