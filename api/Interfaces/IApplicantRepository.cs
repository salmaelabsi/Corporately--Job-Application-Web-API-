using JobApplicationSystem.api.Dtos.Applicant;
using JobApplicationSystem.api.Dtos.Job;
using JobApplicationSystem.api.Models;
using Newtonsoft.Json;

namespace JobApplicationSystem.api.Interfaces
{
    public interface IApplicantRepository
    {
        Task<List<Applicant>> GetAllAsync();
        Task<Applicant?> GetByIdAsync(int id);
        Task<Applicant> CreateAsync(Applicant applicantModel);
        Task<Applicant?> UpdateAsync(int id, Applicant applicantModel);
        Task<Applicant?> DeleteAsync(int id);
    }
}
