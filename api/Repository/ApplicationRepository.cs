using JobApplicationSystem.api.Data;
using JobApplicationSystem.api.Interfaces;
using JobApplicationSystem.api.Models;
using Microsoft.EntityFrameworkCore;

namespace JobApplicationSystem.api.Repository
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly ApplicationDBContext _context;
        public ApplicationRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Application> CreateAsync(Application application)
        {
            await _context.Applications.AddAsync(application);
            await _context.SaveChangesAsync();
            return application;
        }

        public async Task<Application> DeleteApplication(AppUser user, string title)
        {
            var applicationModel = await _context.Applications.FirstOrDefaultAsync(u => u.AppUserId == user.Id && u.Job.JobTitle.ToLower() == title.ToLower());

            if (applicationModel == null) return null;

            _context.Applications.Remove(applicationModel);
            await _context.SaveChangesAsync();
            return applicationModel;
        }

        public async Task<List<Job>> GetUserApplication(AppUser user)
        {
            return await _context.Applications.Where(u => u.AppUserId == user.Id)
                .Select(job => new Job
                {
                    Id = job.JobId,
                    JobTitle = job.Job.JobTitle,
                    CompanyTitle = job.Job.CompanyTitle,
                    Location = job.Job.Location,
                    JobType = job.Job.JobType,
                    WorkMode = job.Job.WorkMode,
                    Industry = job.Job.Industry,
                    ExperienceLevel = job.Job.ExperienceLevel,
                    JobDescription = job.Job.JobDescription,
                    AboutCompany = job.Job.AboutCompany,
                    JobStatus = job.Job.JobStatus,
                    PostedOn = job.Job.PostedOn
                }).ToListAsync();
        }
    }
}
