namespace firstback.UsersOpportunities
{
    public interface IUsersOpportunitiesServices
    {
        Task<IEnumerable<UsersOpportunities>>GetAllAsync();
        Task<UsersOpportunities?> GetByIdAsync(int idUser, int idOpportunity);
        Task<UsersOpportunities>CreateAsync(UsersOpportunityDTO usersOpportunityDTO);
        Task<bool> UpdateAsync(int idUser, int idOpportunity, UsersOpportunityDTO usersOpportunityDTO);
        Task<bool> DeleteAsync(int idUser, int idOpportunity);
    }
}