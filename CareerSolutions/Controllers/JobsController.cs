using CareerSolutions.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CareerSolutions.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public JobsController(AppDbContext context)
        {
            _context = context;
        }
        // GET: api/<JobsController>
        [HttpGet]
        public async Task<ActionResult<List<Job>>> Get()
        {
            return await _context.Jobs.ToListAsync();
        }

        // GET api/<JobsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetJob(int id)
        {
            var job = await _context.Jobs.FindAsync(id);
            if (job == null)
            {
                return NotFound();
            }
            return Ok(job);
        }

        // POST api/<JobsController>
        [HttpPost]
        public async Task<ActionResult<Job>> Post([FromBody] Job value)
        {

            await _context.Jobs.AddAsync(value);
            _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = value.Id }, value);
        }


        [HttpGet("search")]
        public async Task<IActionResult> SearchJobs([FromQuery] string? keyword, [FromQuery] string? location, [FromQuery] string? industry)
        {
            var query = _context.Jobs.AsQueryable();
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(j => j.Title.Contains(keyword) || j.Description.Contains(keyword));
            }
            if (!string.IsNullOrEmpty(location))
            {
                query = query.Where(j => j.Location.Contains(location));
            }
            if (!string.IsNullOrEmpty(industry))
            {
                query = query.Where(j => j.Industry.Contains(industry));
            }
            var jobs = await query.ToListAsync();
            return Ok(jobs);
        }
    }
}
