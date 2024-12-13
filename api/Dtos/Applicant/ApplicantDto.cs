namespace JobApplicationSystem.api.Dtos.Applicant
{
    public class ApplicantDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Summary { get; set; } = string.Empty;
        public string? Experience { get; set; } = string.Empty;
        public string? Education { get; set; } = string.Empty;
        public string HardSkills { get; set; } = string.Empty;
        public string SoftSkills { get; set; } = string.Empty;
        public string CommunitiesAndAwards { get; set; } = string.Empty;
        public string Projects { get; set; } = string.Empty;
        public string? References { get; set; } = string.Empty;
        public string? HyperLinks { get; set; } = string.Empty;
        //public IFormFile? CV{ get; set; }
        public string? CreatedBy { get; set; } = string.Empty;
        public int? JobId { get; set; }
    }
}
