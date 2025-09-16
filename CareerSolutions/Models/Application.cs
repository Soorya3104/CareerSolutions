namespace CareerSolutions.Models
{
    public class Application
    {
        public int ApplicationId { get; set; }
        public int JobSeekerId { get; set; }
        public int JobPostId { get; set; }
        public DateTime AppliedDate { get; set; }

        public JobSeeker JobSeeker { get; set; } = null!;
        public JobPost JobPost { get; set; } = null!;
    }
}
