using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using JobApplicationSystem.api.Dtos.Applicant;
using Microsoft.EntityFrameworkCore;

namespace JobApplicationSystem.api.Models
{
    [Table("Jobs")]
    public class Job
    {
        public int Id { get; set; }
        public string JobTitle { get; set; } = string.Empty;
        public string CompanyTitle { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string JobType { get; set; } = string.Empty;  //part time, full time, contract, internship
        public string WorkMode { get; set; } = string.Empty;   //on-site, hybrid, remote
        public string Industry { get; set; } = string.Empty;
        public string ExperienceLevel { get; set; } = string.Empty;  //entry level, associate, senior, director, executive
        public string JobDescription { get; set; } = string.Empty;
        public string AboutCompany { get; set; } = string.Empty;
        public string JobStatus { get; set; } = string.Empty;  //recruiting, application closed
        public DateTime PostedOn { get; set; }
        public List<Applicant> Applicants { get; set; } = new List<Applicant>();
        public List<Application> Applications { get; set; } = new List<Application>();
    }
}
