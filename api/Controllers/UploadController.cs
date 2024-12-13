using JobApplicationSystem.api.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace JobApplicationSystem.api.Controllers
{
    [ApiController]
    [Route("api/upload")]
    public class UploadController : ControllerBase
    {
        [HttpPost]
        public IActionResult UploadFile([FromForm] List<IFormFile> files) {
           // if (file == null || file.Length == 0)
             //   return BadRequest("No file uploaded");
             if (files.Count == 0)
                return BadRequest("No file uploaded");
            return Ok(new UploadHandler().Upload(files[0]));
        }
    }
}
