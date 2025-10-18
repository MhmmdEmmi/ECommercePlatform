using Microsoft.AspNetCore.Http;

namespace ECommercePlatform.Services
{
    public interface IFileUploadService
    {
        Task<string> UploadImageAsync(IFormFile file, string folder);
        Task<string> UploadDocumentAsync(IFormFile file, string folder);
        bool DeleteFile(string filePath);
    }
}