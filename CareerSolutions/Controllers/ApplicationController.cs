using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CareerSolutions.Models;

namespace CareerSolutions.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
       private readonly AppDbContext _context;
       public ApplicationController(AppDbContext context)
         {
              _context = context;
         }
        [HttpPost]
        public async Task<IActionResult> Apply([FromBody] Application application)
        {
            if (application == null)
            {
                return BadRequest("Application is mising");
            }
            application.AppliedDate = DateTime.Now;
            _context.Applications.Add(application);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Application submitted successfully." });
        }

        [HttpGet("ByJobSeeker/{jobSeekerId}")]
        public async Task<IActionResult> GetApplicationsByJobSeeker(int jobSeekerId)
        {
            var applications = await _context.Applications
                .Include(a => a.JobPost)
                .Where(a => a.JobSeekerId == jobSeekerId)
                .ToListAsync();
            return Ok(applications);
        }
    }
}
