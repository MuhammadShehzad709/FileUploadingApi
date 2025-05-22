
namespace PDF_Uploading.FileUploadServices
{
    public class FileUploadService(IWebHostEnvironment env) : IFileUploadService
    {
        public async Task<string> UploadPdfAsync(IFormFile file)
        {
            var extension = Path.GetExtension(file.FileName).ToLower();
            if (extension != ".pdf")
            {
                throw new ArgumentException("Only Pdf File are allowed");
            }
            string folderPath = Path.Combine(env.ContentRootPath, "UploadedFiles");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            string fileName = Guid.NewGuid().ToString() + extension;
            string filePath = Path.Combine(folderPath, fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return $"/files/{fileName}";

        }


    }
}
