using JobApplicationSystem.api.Dtos.Job;
using System.Linq.Expressions;
using JobApplicationSystem.api.Models;
using System.Runtime.CompilerServices;

namespace JobApplicationSystem.api.Mappers
{
    public static class JobMappers
    {
        public static JobDto ToJobDto(this Job jobModel)
        {
            return new JobDto
            {
                Id = jobModel.Id,
                JobTitle = jobModel.JobTitle,
                CompanyTitle = jobModel.CompanyTitle,
                Location = jobModel.Location,
                Industry = jobModel.Industry,
                ExperienceLevel = jobModel.ExperienceLevel,
                JobDescription = jobModel.JobDescription,
                JobType = jobModel.JobType,
                JobStatus = jobModel.JobStatus,
                WorkMode = jobModel.WorkMode,
                AboutCompany = jobModel.AboutCompany,
                PostedOn = jobModel.PostedOn,
               // Applicants = jobModel.Applicants.Select(a => a.ToApplicantDto()).ToList()
            };       
        }

        public static Job ToJobFromCreateDto(this CreateJobRequestDto jobRequestDto)
        {
            return new Job
            {
                JobTitle = jobRequestDto.JobTitle,
                CompanyTitle = jobRequestDto.CompanyTitle,
                Location = jobRequestDto.Location,
                JobType = jobRequestDto.JobType,
                WorkMode = jobRequestDto.WorkMode,
                Industry = jobRequestDto.Industry,
                ExperienceLevel = jobRequestDto.ExperienceLevel,
                JobDescription = jobRequestDto.JobDescription,
                AboutCompany = jobRequestDto.AboutCompany,
                JobStatus = jobRequestDto.JobStatus,
                PostedOn = jobRequestDto.PostedOn
            };
        }
    }
}
