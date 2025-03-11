using BackendProject.Data;
using Microsoft.EntityFrameworkCore;

namespace firstback.UsersOpportunities
{
    public class UsersOpportunitiesServices : IUsersOpportunitiesServices
    {
        private readonly ApplicationDbContext _context;

        public UsersOpportunitiesServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UsersOpportunities>> GetAllAsync()
        {
            return await _context.UsersOpportunities
            .Include(uo => uo.user)
            .Include(uo => uo.Oportunidad)
            .ToListAsync();
        }

        public async Task<UsersOpportunities?> GetByIdAsync(int userId, int opportunityId)
        {
            return await _context.UsersOpportunities
            .Include(uo => uo.user)
            .Include(uo => uo.Oportunidad)
            .FirstOrDefaultAsync(uo => uo.IdUser == userId && uo.IdOpportunity == opportunityId);
        }

        public async Task<UsersOpportunities> CreateAsync(UsersOpportunityDTO usersOpportunityDTO)
        {
            var userOpportunities = UsersOpportunitiesMapper.MapToEntity(usersOpportunityDTO);

            _context.UsersOpportunities.Add(userOpportunities);
            await _context.SaveChangesAsync();

            return await GetByIdAsync(userOpportunities.IdUser, userOpportunities.IdOpportunity) ?? userOpportunities;
        }

        public async Task<bool> UpdateAsync(int userId, int opportunityId, UsersOpportunityDTO usersOpportunityDTO)
        {
            var userOpportunities = await GetByIdAsync(userId, opportunityId);
            if (userOpportunities == null) return false;

            userOpportunities.IdUser = usersOpportunityDTO.UserId;
            userOpportunities.IdOpportunity = usersOpportunityDTO.OpportunityId;

            _context.Entry(userOpportunities).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int userId, int opportunityId)
        {
            var userOpportunities = await GetByIdAsync(userId, opportunityId);
            if (userOpportunities == null) return false;

            _context.UsersOpportunities.Remove(userOpportunities);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}