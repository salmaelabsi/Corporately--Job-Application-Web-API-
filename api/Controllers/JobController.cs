using JobApplicationSystem.api.Data;
using JobApplicationSystem.api.Dtos.Job;
using JobApplicationSystem.api.Helpers;
using JobApplicationSystem.api.Interfaces;
using JobApplicationSystem.api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobApplicationSystem.api.Controllers
{
    [Route("api/job")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IJobRepository _jobRepo;
        public JobController(ApplicationDBContext context, IJobRepository jobRepo)
        {
            _jobRepo = jobRepo;
            _context = context;
        }

        [HttpGet("JobsList")]
        public async Task<IActionResult> GetAllAsync([FromQuery] QueryObject query)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var jobs = await _jobRepo.GetAllAsync(query);
            var jobDto = jobs.Select(j => j.ToJobDto()).ToList();

            return Ok(jobDto);
        }

        [HttpGet("GetJobByID/{id:int}")]
        //[Authorize]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var job = await _jobRepo.GetByIdAsync(id);

            if (job == null)
            {
                return NotFound();
            }
            return Ok(JobMappers.ToJobDto(job));
        }

        [HttpPost("CreateNewJob")]
        //[Authorize]
        public async Task<IActionResult> Create([FromBody]CreateJobRequestDto jobDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var jobModel = jobDto.ToJobFromCreateDto();

            await _jobRepo.CreateAsync(jobModel);

            return CreatedAtAction(nameof(GetById), new { id = jobModel.Id }, jobModel.ToJobDto());
        }

        [HttpPut]
        [Route("UpdateExistingJob/{id:int}")]
        //[Authorize]
        public async Task<IActionResult> UpdateJob([FromRoute] int id, [FromBody] UpdateJobRequestDto updateDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var jobModel = await _jobRepo.UpdateAsync(id, updateDto);

            if (jobModel == null) return NotFound();

            return Ok(jobModel.ToJobDto());

        }

        [HttpDelete]
        [Route("DeleteJob/{id:int}")]
        //[Authorize]
        public async Task<IActionResult> DeleteJob([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var jobModel = await _jobRepo.DeleteAsync(id);

            if (jobModel == null) return NotFound();

            return NoContent();
        }

    }
}