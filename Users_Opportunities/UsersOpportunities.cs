using System.ComponentModel.DataAnnotations.Schema;
using firstback.Oportunidades;
using firstback.user;

namespace firstback.UsersOpportunities
{
    public class UsersOpportunities
    {
        [ForeignKey("User")]
        public int IdUser { get; set; }
        [ForeignKey("Oportunidad")]
        public int IdOpportunity { get; set; }

        public User user { get; set; } = null!;
        public Oportunidad Oportunidad { get; set; } = null!;
    }
}