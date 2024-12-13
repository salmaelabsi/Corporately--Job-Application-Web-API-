using JobApplicationSystem.api.Dtos.Applicant;
using JobApplicationSystem.api.Extensions;
using JobApplicationSystem.api.Interfaces;
using JobApplicationSystem.api.Mappers;
using JobApplicationSystem.api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JobApplicationSystem.api.Controllers
{
    [ApiController]
    [Route("api/applicant")]
    public class ApplicantController:ControllerBase
    {
        private readonly IApplicantRepository _applicantRepo;
        private readonly IJobRepository _jobRepo;
        private readonly UserManager<AppUser> _userManager;

        public ApplicantController(IApplicantRepository applicantRepo, IJobRepository jobRepo, UserManager<AppUser> userManager)
        {
            _applicantRepo = applicantRepo;
            _jobRepo = jobRepo;
            _userManager = userManager;
        }

        [HttpGet("ApplicantsList")]
        public async Task<IActionResult> GetAll()
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var applicants = await _applicantRepo.GetAllAsync();

            var applicantDto = applicants.Select(x => x.ToApplicantDto());

            return Ok(applicantDto);
        }

        [HttpGet("GetApplicantByID/{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id) 
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var applicant = await _applicantRepo.GetByIdAsync(id);

            if(applicant == null)
                return NotFound();

            return Ok(applicant.ToApplicantDto());
        }

        [HttpPost("CreateApplicationByJobId/{jobId:int}")]
        public async Task<IActionResult> Create([FromRoute] int jobId, CreateApplicantDto applicantDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (!await _jobRepo.JobExists(jobId)) return BadRequest("Job does not exist!");

            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);

            var applicantModel = applicantDto.ToApplicantFromCreate(jobId);

            applicantModel.AppUserId = appUser.Id;

            await _applicantRepo.CreateAsync(applicantModel);
            
            return CreatedAtAction(nameof(GetById), new { id = applicantModel.Id }, applicantModel.ToApplicantDto());
        }

        [HttpPut]
        [Route("UpdateApplicant/{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateApplicantDto updateDto) 
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var applicant = await _applicantRepo.UpdateAsync(id, updateDto.ToApplicantFromUpdate());

            if (applicant == null) return NotFound("Applicant not found!");

            return Ok(applicant.ToApplicantDto());
        }

        [HttpDelete]
        [Route("DeleteApplicant/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id) 
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var applicantModel = await _applicantRepo.DeleteAsync(id);
            if (applicantModel == null) return NotFound("Applicant does not exist!");
            return Ok(applicantModel);

        }
    }
}
