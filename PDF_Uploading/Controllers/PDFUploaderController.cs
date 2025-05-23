﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PDF_Uploading.FileUploadServices;

namespace PDF_Uploading.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PDFUploaderController(IFileUploadService service) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> UploadPdf(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("File not selected");
            }
            try
            {
                var filePath = await service.UploadPdfAsync(file);
                return Ok(new { path = filePath });
            }
            catch (Exception ex)
            {

                return BadRequest($"{ex.Message}");
            }

        }
    }
}
