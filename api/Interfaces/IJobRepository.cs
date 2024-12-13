using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobApplicationSystem.api.Dtos.Job;
using JobApplicationSystem.api.Helpers;
using JobApplicationSystem.api.Models;

namespace JobApplicationSystem.api.Interfaces
{
    public interface IJobRepository
    {
        Task<List<Job>> GetAllAsync(QueryObject query);
        Task<Job?> GetByIdAsync(int id);
        Task<Job?> GetByTitleAsync(string title);
        Task<Job?> CreateAsync(Job jobModel);
        Task<Job?> UpdateAsync(int id, UpdateJobRequestDto updateDto);
        Task<Job?> DeleteAsync(int id);
        Task<bool> JobExists(int id);
    }
}
