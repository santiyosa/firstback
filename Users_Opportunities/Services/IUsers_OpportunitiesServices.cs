using Users_Opportunities.DTO;
using Users_Opportunities.Models;

namespace Users_Opportunities.Sevices
{
    public interface IUsers_OpportunitiesServices
    {
        Task<IEnumerable<UserOpportunity>>GetAllAsync();
        Task<UserOpportunity>CreateAsync(UsersOpportunityDTO usersOpportunityDTO);
        Task DeleteAsync(UsersOpportunityDTO usersOpportunityDTO);
    }

}