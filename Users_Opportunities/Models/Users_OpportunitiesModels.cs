namespace Users_Opportunities.Models
{
namespace Users_Opportunities.Models
{
    public class UserOpportunity
    {
        public int UserId { get; set; }
        public int OpportunityId { get; set; }

        public virtual User User { get; set; }
        public virtual Opportunity Opportunity { get; set; }
    }

        public class User
        {
        }

        public class Opportunity
        {
        }
    }
}