using JobApplicationSystem.api.Data;
using JobApplicationSystem.api.Dtos.Job;
using JobApplicationSystem.api.Helpers;
using JobApplicationSystem.api.Interfaces;
using JobApplicationSystem.api.Mappers;
using JobApplicationSystem.api.Models;
using Microsoft.EntityFrameworkCore;

namespace JobApplicationSystem.api.Repository
{
    public class JobRepository : IJobRepository
    {
        private readonly ApplicationDBContext _context;
        public JobRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Job?> CreateAsync(Job jobModel)
        {
            await _context.Jobs.AddAsync(jobModel);
            await _context.SaveChangesAsync();
            return jobModel;
        }

        public async Task<Job?> DeleteAsync(int id)
        {
            var jobModel = await _context.Jobs.FirstOrDefaultAsync(x => x.Id == id);
            if (jobModel == null) return null;
            _context.Jobs.Remove(jobModel);
            await _context.SaveChangesAsync();
            return jobModel;
        }

        public async Task<List<Job>> GetAllAsync(QueryObject query)
        {
            var jobs = _context.Jobs.Include(a => a.Applicants).ThenInclude(u => u.AppUser).AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.JobType))
            {
                jobs = jobs.Where(s => s.JobType.Contains(query.JobType));
            }

            if (!string.IsNullOrWhiteSpace(query.WorkMode))
            {
                jobs = jobs.Where(s => s.WorkMode.Contains(query.WorkMode));
            }

            if (!string.IsNullOrWhiteSpace(query.Industry))
            {
                jobs = jobs.Where(s => s.Industry.Contains(query.Industry));
            }

            if (!string.IsNullOrWhiteSpace(query.ExperienceLevel))
            {
                jobs = jobs.Where(s => s.ExperienceLevel.Contains(query.ExperienceLevel));
            }

            if (!string.IsNullOrWhiteSpace(query.JobStatus))
            {
                jobs = jobs.Where(s => s.JobStatus.Contains(query.JobStatus));
            }

            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("Industry"))
                {
                    jobs = query.IsDescending ? jobs.OrderByDescending(i => i.Industry) : jobs.OrderBy(i => i.Industry);
                }
            }

            var skipNumber = (query.PageNumber - 1) * query.PageSize;


            return await jobs.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

        public async Task<Job?> GetByIdAsync(int id)
        {
            return await _context.Jobs.Include(a => a.Applicants).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Job?> GetByTitleAsync(string title)
        {
            return await _context.Jobs.FirstOrDefaultAsync(t => t.JobTitle == title);
        }

        public Task<bool> JobExists(int id)
        {
            return _context.Jobs.AnyAsync(a => a.Id == id);
        }

        public async Task<Job?> UpdateAsync(int id, UpdateJobRequestDto jobDto)
        {
            var existingJob = await _context.Jobs.FirstOrDefaultAsync(x => x.Id == id);
            if (existingJob == null) return null;

            existingJob.JobTitle = jobDto.JobTitle;
            existingJob.CompanyTitle = jobDto.CompanyTitle;
            existingJob.Location = jobDto.Location;
            existingJob.JobType = jobDto.JobType;
            existingJob.WorkMode = jobDto.WorkMode;
            existingJob.Industry = jobDto.Industry;
            existingJob.ExperienceLevel = jobDto.ExperienceLevel;
            existingJob.JobDescription = jobDto.JobDescription;
            existingJob.AboutCompany = jobDto.AboutCompany;
            existingJob.JobStatus = jobDto.JobStatus;
            existingJob.PostedOn = jobDto.PostedOn;

            await _context.SaveChangesAsync();
            return existingJob;
        }
    }
}
