using Microsoft.EntityFrameworkCore;
namespace CareerSolutions.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Job> Jobs { get; set; }
    }
}
