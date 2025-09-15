using System.ComponentModel.DataAnnotations;

namespace CareerSolutions.Models
{
    public class Job
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Industry { get; set; }
        public string specialization { get; set; }
        public string Location { get; set; }
        public int Salary { get; set; }
        public DateTime PostedDate { get; set; }


    }
}
