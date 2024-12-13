using JobApplicationSystem.api.Dtos.Applicant;

namespace JobApplicationSystem.api.Dtos.Job
{
    public class JobDto
    {
        public int Id { get; set; }
        public string JobTitle { get; set; } = string.Empty;
        public string CompanyTitle { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string JobType { get; set; } = string.Empty;
        public string WorkMode { get; set; } = string.Empty; 
        public string Industry { get; set; } = string.Empty;
        public string ExperienceLevel { get; set; } = string.Empty;  
        public string JobDescription { get; set; } = string.Empty;
        public string AboutCompany { get; set; } = string.Empty;
        public string JobStatus { get; set; } = string.Empty; 
        public DateTime PostedOn { get; set; }
        public List<ApplicantDto>? Applicants { get; set; }
    }
}
