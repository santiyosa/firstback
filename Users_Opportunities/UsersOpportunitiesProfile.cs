namespace firstback.UsersOpportunities
{
    public class UsersOpportunitiesMapper
    {
        public static UsersOpportunities MapToEntity(UsersOpportunityDTO dto)
        {
            return new UsersOpportunities
            {
                IdUser = dto.UserId,
                IdOpportunity = dto.OpportunityId
            };
        }
    }
}
