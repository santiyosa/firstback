

using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace User_Opportunities.Models
{
public class UserOpportunities
{
   
    public int Id_User { get; set; }
    public int Id_Oportunities { get; set; }
    public required ICollection<UserOpportunities> UserOpportunities {get; set;}    

}
}