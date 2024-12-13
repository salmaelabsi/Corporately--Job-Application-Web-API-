using JobApplicationSystem.api.Extensions;
using JobApplicationSystem.api.Interfaces;
using JobApplicationSystem.api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JobApplicationSystem.api.Controllers
{
    [Route("api/application")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IJobRepository _jobRepo;
        private readonly IApplicationRepository _applicationRepo;

        public ApplicationController(UserManager<AppUser> userManager, IJobRepository jobRepo, IApplicationRepository applicationRepo)
        {
            _userManager = userManager;
            _jobRepo = jobRepo;
            _applicationRepo = applicationRepo;
        }

        [HttpGet("GetUserApplication")]
        [Authorize]
        public async Task<IActionResult> GetUserApplication()
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            var userApplication = await _applicationRepo.GetUserApplication(appUser);

            return Ok(userApplication);
        }

        [HttpPost("AddApplicationByJobTitle")]
        [Authorize]
        public async Task<IActionResult> AddApplication(string title)
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            var job = await _jobRepo.GetByTitleAsync(title);

            if (job == null) return BadRequest("Job not found!");

            var userApplication = await _applicationRepo.GetUserApplication(appUser);

            if (userApplication.Any(x => x.JobTitle.ToLower() == title.ToLower())) return BadRequest("Cannot apply to the same job twice!");

            var applicationModel = new Application
            {
                JobId = job.Id,
                AppUserId = appUser.Id
            };

            await _applicationRepo.CreateAsync(applicationModel);

            if (applicationModel == null)
            {
                return StatusCode(500, "Could not create!");
            }
            else
            {
                return Created();
            }
        }

        [HttpDelete("DeleteApplicationByJobTitle")]
        [Authorize]
        public async Task<IActionResult> DeleteApplication(string title)
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);

            var userApplication = await _applicationRepo.GetUserApplication(appUser);

            var filteredJob = userApplication.Where(t => t.JobTitle.ToLower() == title.ToLower()).ToList();
            if (filteredJob.Count() == 1)
            {
                await _applicationRepo.DeleteApplication(appUser, title);
            }
            else 
            {
                return BadRequest("Job is not in your applications!");
            }

            return Ok();
        }
    }
}
