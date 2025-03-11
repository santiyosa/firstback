using Microsoft.AspNetCore.Mvc;

namespace firstback.UsersOpportunities
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersOpportunitiesController : ControllerBase
    {
        private readonly IUsersOpportunitiesServices _service;

        public UsersOpportunitiesController(IUsersOpportunitiesServices service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsersOpportunities>>> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{userId}/{opportunityId}")]
        public async Task<ActionResult<UsersOpportunities>> GetById(int userId, int opportunityId)
        {
            var result = await _service.GetByIdAsync(userId, opportunityId);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<UsersOpportunities>> CreateUserOpportunity([FromBody] UsersOpportunityDTO usersOpportunityDTO)
        {
            var created = await _service.CreateAsync(usersOpportunityDTO);
            return CreatedAtAction(nameof(GetById), new { userId = created.IdUser, opportunityId = created.IdOpportunity }, created);
        }

        [HttpPut("{userId}/{opportunityId}")]
        public async Task<IActionResult> Update(int userId, int opportunityId, [FromBody] UsersOpportunityDTO usersOpportunityDTO)
        {
            var updated = await _service.UpdateAsync(userId, opportunityId, usersOpportunityDTO);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{userId}/{opportunityId}")]
        public async Task<IActionResult> Delete(int userId, int opportunityId)
        {
            var deleted = await _service.DeleteAsync(userId, opportunityId);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}