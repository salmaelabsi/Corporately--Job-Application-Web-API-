using System.ComponentModel.DataAnnotations;

namespace JobApplicationSystem.api.Dtos.Job
{
    public class CreateJobRequestDto
    {
        [Required]
        [MinLength(2, ErrorMessage = "Title must be at least 2 characters")]
        [MaxLength(25, ErrorMessage = "Title cannot be over 25 characters")]
        public string JobTitle { get; set; } = string.Empty;
        [Required]
        [MinLength(2, ErrorMessage = "Title must be at least 2 characters")]
        [MaxLength(25, ErrorMessage = "Title cannot be over 25 characters")]
        public string CompanyTitle { get; set; } = string.Empty;
        [Required]
        [MinLength(2, ErrorMessage = "Location must be at least 2 characters")]
        [MaxLength(25, ErrorMessage = "Location cannot be over 25 characters")]
        public string Location { get; set; } = string.Empty;
        [Required]
        [MinLength(1, ErrorMessage = "Job Type must be at least 4 characters")]
        [MaxLength(25, ErrorMessage = "Job Type cannot be over 25 characters")]
        public string JobType { get; set; } = string.Empty;
        [Required]
        [MinLength(1, ErrorMessage = "Work Mode must be at least 4 characters")]
        [MaxLength(25, ErrorMessage = "Work Mode cannot be over 25 characters")]
        public string WorkMode { get; set; } = string.Empty;   
        [Required]
        [MinLength(1, ErrorMessage = "Industry must be at least 4 characters")]
        [MaxLength(25, ErrorMessage = "Industry cannot be over 25 characters")]
        public string Industry { get; set; } = string.Empty;
        [Required]
        [MinLength(1, ErrorMessage = "Experience Level must be at least 4 characters")]
        [MaxLength(25, ErrorMessage = "Experience Level cannot be over 25 characters")]
        public string ExperienceLevel { get; set; } = string.Empty;  
        [Required]
        [MinLength(1, ErrorMessage = "Job Description must be at least 15 characters")]
        [MaxLength(500, ErrorMessage = "Job Description cannot be over 500 characters")]
        public string JobDescription { get; set; } = string.Empty;
        [Required]
        [MinLength(1, ErrorMessage = "About Company must be at least 15 characters")]
        [MaxLength(280, ErrorMessage = "About Company cannot be over 500 characters")]
        public string AboutCompany { get; set; } = string.Empty;
        [Required]
        [MinLength(2, ErrorMessage = "Job Status must be at least 4 characters")]
        [MaxLength(25, ErrorMessage = "Job Status cannot be over 25 characters")]
        public string JobStatus { get; set; } = string.Empty; 
        [Required]
        public DateTime PostedOn { get; set; }
    }
}
