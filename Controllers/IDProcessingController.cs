using Microsoft.AspNetCore.Mvc;
using OCR_FE.Services;
using System.IO;
using System.Threading.Tasks;

namespace OCR_FE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IDProcessingController : ControllerBase
    {
        private readonly IChatGPTService _chatGPTService;

        public IDProcessingController(IChatGPTService chatGPTService)
        {
            _chatGPTService = chatGPTService;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadID(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            try
            {
                // Temporary storage path
                var tempFilePath = Path.GetTempFileName();

                // Save the file temporarily
                using (var stream = new FileStream(tempFilePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                // Process the file using ChatGPTService (not implemented here)
                // This might involve extracting text from the image and sending it to the ChatGPT API
                var result = await _chatGPTService.ProcessImageAsync(tempFilePath);

                // Remove the temporary file
                System.IO.File.Delete(tempFilePath);

                return Ok(result);
            }
            catch (Exception ex)
            {
                // Log the exception (logging not implemented here)
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
    }
}
