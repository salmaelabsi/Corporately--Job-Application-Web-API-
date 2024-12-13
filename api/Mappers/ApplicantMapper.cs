using JobApplicationSystem.api.Dtos.Applicant;
using JobApplicationSystem.api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace JobApplicationSystem.api.Mappers
{
    public static class ApplicantMapper
    {
        public static ApplicantDto ToApplicantDto(this Applicant applicantModel)
        {
            return new ApplicantDto
            {
                Id = applicantModel.Id,
                Name = applicantModel.Name,
                Title = applicantModel.Title,
                Address = applicantModel.Address,
                Email = applicantModel.Email,
                Phone = applicantModel.Phone,
                Summary = applicantModel.Summary,
                Experience = applicantModel.Experience,
                Education = applicantModel.Education,
                HardSkills = applicantModel.HardSkills,
                SoftSkills = applicantModel.SoftSkills,
                CommunitiesAndAwards = applicantModel.CommunitiesAndAwards,
                Projects = applicantModel.Projects,
                References = applicantModel.References,
                HyperLinks = applicantModel.HyperLinks,
                //CV = applicantModel.CV,
                CreatedBy = applicantModel.AppUser.UserName,
                JobId = applicantModel.JobId
            };
        }

        public static Applicant ToApplicantFromCreate(this CreateApplicantDto applicantDto, int jobId)
        {
            return new Applicant
            {                
                Name = applicantDto.Name,
                Title = applicantDto.Title,
                Address = applicantDto.Address,
                Email = applicantDto.Email,
                Phone = applicantDto.Phone,
                Summary = applicantDto.Summary,
                Experience = applicantDto.Experience,
                Education = applicantDto.Education,
                HardSkills = applicantDto.HardSkills,
                SoftSkills = applicantDto.SoftSkills,
                CommunitiesAndAwards = applicantDto.CommunitiesAndAwards,
                Projects = applicantDto.Projects,
                References = applicantDto.References,
                HyperLinks = applicantDto.HyperLinks,
                //CV = applicantDto.CV,
                JobId = jobId
            };
        }

        public static Applicant ToApplicantFromUpdate(this UpdateApplicantDto applicantDto)
        {
            return new Applicant
            {
                Name = applicantDto.Name,
                Title = applicantDto.Title,
                Address = applicantDto.Address,
                Email = applicantDto.Email,
                Phone = applicantDto.Phone,
                Summary = applicantDto.Summary,
                Experience = applicantDto.Experience,
                Education = applicantDto.Education,
                HardSkills = applicantDto.HardSkills,
                SoftSkills = applicantDto.SoftSkills,
                CommunitiesAndAwards = applicantDto.CommunitiesAndAwards,
                Projects = applicantDto.Projects,
                References = applicantDto.References,
                HyperLinks = applicantDto.HyperLinks,
                //CV = applicantDto.CV
            };
        }
    }
}
