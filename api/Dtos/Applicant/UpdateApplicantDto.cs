using System.ComponentModel.DataAnnotations;

namespace JobApplicationSystem.api.Dtos.Applicant
{
    public class UpdateApplicantDto
    {
        [Required]
        [MinLength(2, ErrorMessage = "Name must be at least 2 characters")]
        [MaxLength(25, ErrorMessage = "Name cannot be over 25 characters")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MinLength(2, ErrorMessage = "Title must be at least 2 characters")]
        [MaxLength(25, ErrorMessage = "Title cannot be over 25 characters")]
        public string Title { get; set; } = string.Empty;
        [Required]
        [MinLength(10, ErrorMessage = "Address must be at least 10 characters")]
        [MaxLength(50, ErrorMessage = "Address cannot be over 50 characters")]
        public string Address { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        [MinLength(10, ErrorMessage = "Phone must be at least 10 characters")]
        [MaxLength(14, ErrorMessage = "Phone cannot be over 14 characters")]
        public string Phone { get; set; } = string.Empty;
        [Required]
        [MinLength(10, ErrorMessage = "Summary must be at least 10 characters")]
        [MaxLength(120, ErrorMessage = "Summary cannot be over 120 characters")]
        public string Summary { get; set; } = string.Empty;
        [Required]
        [MinLength(10, ErrorMessage = "Experience must be at least 10 characters")]
        [MaxLength(280, ErrorMessage = "Experience cannot be over 280 characters")]
        public string? Experience { get; set; } = string.Empty;
        [Required]
        [MinLength(10, ErrorMessage = "Education must be at least 10 characters")]
        [MaxLength(280, ErrorMessage = "Education cannot be over 280 characters")]
        public string? Education { get; set; } = string.Empty;
        [Required]
        [MinLength(10, ErrorMessage = "Hard Skills must be at least 10 characters")]
        [MaxLength(120, ErrorMessage = "Hard Skills cannot be over 120 characters")]
        public string HardSkills { get; set; } = string.Empty;
        [Required]
        [MinLength(10, ErrorMessage = "Soft Skills must be at least 10 characters")]
        [MaxLength(120, ErrorMessage = "Soft Skills cannot be over 120 characters")]
        public string SoftSkills { get; set; } = string.Empty;
        [Required]
        [MinLength(10, ErrorMessage = "Communities And Awards must be at least 10 characters")]
        [MaxLength(280, ErrorMessage = "Communities And Awards cannot be over 280 characters")]
        public string CommunitiesAndAwards { get; set; } = string.Empty;
        [Required]
        [MinLength(10, ErrorMessage = "Projects must be at least 10 characters")]
        [MaxLength(280, ErrorMessage = "Projects And Awards cannot be over 280 characters")]
        public string Projects { get; set; } = string.Empty;
        [Required]
        [MinLength(10, ErrorMessage = "References must be at least 10 characters")]
        [MaxLength(120, ErrorMessage = "References And Awards cannot be over 120 characters")]
        public string? References { get; set; } = string.Empty;
        [Required]
        [MinLength(10, ErrorMessage = "HyperLinks must be at least 10 characters")]
        [MaxLength(120, ErrorMessage = "HyperLinks And Awards cannot be over 120 characters")]
        public string? HyperLinks { get; set; } = string.Empty;
        //[Required]
        //public string CV { get; set; } = string.Empty;
    }
}
