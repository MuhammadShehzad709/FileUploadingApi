namespace PDF_Uploading.FileUploadServices
{
    public interface IFileUploadService
    {
        Task<string>UploadPdfAsync(IFormFile File);
    }
}
