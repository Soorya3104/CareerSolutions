using Microsoft.EntityFrameworkCore;
namespace CareerSolutions.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<ApplicationBuilder> Applications { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<Job>().HasData(

        //        new Job
        //        {
        //            Id = 1,
        //            Title = "Software Engineer",
        //            Description = "Looking for C# & SQL",
        //            Industry = "IT",
        //            specialization = "FullStack Developer",
        //            Location = "Bengaluru",
        //            Salary = 450000,
        //            PostedDate = DateTime.Now.AddDays(-10)
        //        },
        //        new Job
        //        {
        //            Id = 2,
        //            Title = "Software Engineer",
        //            Description = "5+ years of Experience in .NET",
        //            Industry = "IT",
        //            specialization = "Fullstack Developer",
        //            Location = "Chennai",
        //            Salary = 1000000,
        //            PostedDate = DateTime.Now.AddDays(-5)
        //        }
        //    );
        //}
    }
}
