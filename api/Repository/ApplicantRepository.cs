using JobApplicationSystem.api.Data;
using JobApplicationSystem.api.Dtos.Applicant;
using JobApplicationSystem.api.Interfaces;
using JobApplicationSystem.api.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace JobApplicationSystem.api.Repository
{
    public class ApplicantRepository : IApplicantRepository
    {
        private readonly ApplicationDBContext _context;
        public ApplicantRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Applicant>> GetAllAsync()
        {
                return await _context.Applicants.Include(a => a.AppUser).ToListAsync();
        }

        public async Task<Applicant?> GetByIdAsync(int id)
        {
            return await _context.Applicants.Include(a => a.AppUser).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Applicant?> UpdateAsync(int id, Applicant applicantModel)
        {
            var existingAplicant = await _context.Applicants.FindAsync(id);
            if (existingAplicant == null) return null;

            existingAplicant.Name = applicantModel.Name;
            existingAplicant.Title = applicantModel.Title;
            existingAplicant.Address = applicantModel.Address;
            existingAplicant.Email = applicantModel.Email;
            existingAplicant.Phone = applicantModel.Phone;
            existingAplicant.Summary = applicantModel.Summary;
            existingAplicant.Experience = applicantModel.Experience;
            existingAplicant.Education = applicantModel.Education;
            existingAplicant.HardSkills = applicantModel.HardSkills;
            existingAplicant.SoftSkills = applicantModel.SoftSkills;
            existingAplicant.CommunitiesAndAwards = applicantModel.CommunitiesAndAwards;
            existingAplicant.Projects = applicantModel.Projects;
            existingAplicant.References = applicantModel.References;
            existingAplicant.HyperLinks = applicantModel.HyperLinks;
            //existingAplicant.CV = applicantModel.CV;

            await _context.SaveChangesAsync();
            return existingAplicant;
        }

        public async Task<Applicant> CreateAsync(Applicant applicantModel)
        {
            await _context.Applicants.AddAsync(applicantModel);
            await _context.SaveChangesAsync();
            return applicantModel;
        }
        
        public async Task<Applicant?> DeleteAsync(int id)
        {
            var applicantModel = await _context.Applicants.FirstOrDefaultAsync(a => a.Id == id);
            if (applicantModel == null) return null;

            _context.Applicants.Remove(applicantModel);
            await _context.SaveChangesAsync();
            return applicantModel;
        }

    }
}
