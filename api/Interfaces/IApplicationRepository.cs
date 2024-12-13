using JobApplicationSystem.api.Models;

namespace JobApplicationSystem.api.Interfaces
{
    public interface IApplicationRepository 
    {
        Task<List<Job>> GetUserApplication(AppUser user);
        Task<Application> CreateAsync(Application application);
        Task<Application> DeleteApplication(AppUser user, string title);
    }
}
