using Users_Opportunities.Models;
using Microsoft.AspNetCore.Mvc;
using BackendProject.Data;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class UsersOpportunitiesController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public UsersOpportunitiesController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserOpportunityDTO>>> GetUsersOpportunities()
    {
        var userOpportunities = await _context.UsersOpportunities
            .Select(uo => new UserOpportunityDTO
            {
                UserId = uo.UserId,
                OpportunityId = uo.OpportunityId
            }).ToListAsync();

        return Ok(userOpportunities);
    }

    [HttpPost]
    public async Task<ActionResult<UserOpportunityDTO>> CreateUserOpportunity(UserOpportunityDTO dto)
    {
       

        var userOpportunity = new UserOpportunity
        {
            UserId = dto.UserId,
            OpportunityId = dto.OpportunityId
        };

        _context.UsersOpportunities.Add(userOpportunity);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetUsersOpportunities), new { userId = dto.UserId, opportunityId = dto.OpportunityId }, dto);
    }

    [HttpPut("{userId}/{opportunityId}")]
    public async Task<IActionResult> UpdateUserOpportunity(int userId, int opportunityId, UserOpportunityDTO dto)
    {
        
    }

    [HttpDelete("{userId}/{opportunityId}")]
    public async Task<IActionResult> DeleteUserOpportunity(int userId, int opportunityId)
    {
       
    }
}

internal class UserOpportunity
{
    public int UserId { get; set; }
    public int OpportunityId { get; set; }
}

public class UserOpportunityDTO
{
    internal int OpportunityId;

    public int UserId { get; internal set; }
}