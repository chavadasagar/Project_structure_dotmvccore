using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Please select a file to upload.");

            // Get the filename
            var fileName = Path.GetFileName(file.FileName);

            // Define the file path
            var filePath = Path.Combine(Directory.GetCurrentDirectory(),"uploadedfiles", fileName);

            // Save the file to disk
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Ok(new { fileName });
        }
    }
}
