

namespace User_OpportunitiesApi.Services
{
    public interface IUserOpportunitiesService
    {
        IEnumerable<UserOpportunities> GetAll();
        UserOpportunities GetById(int id);
        void Create(UserOpportunities userOpportunities);
        void Update(int  id, UserOpportunities);
        void Delete(int id);

    }

    public class UserOpportunities
    {
    }
}