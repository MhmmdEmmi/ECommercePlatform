using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading.Tasks;

namespace ECommercePlatform.Services
{
    public class FileUploadService : IFileUploadService
    {
        private readonly string _uploadPath;

        public FileUploadService(IConfiguration configuration)
        {
            _uploadPath = configuration["FileUploadSettings:UploadPath"] ?? "Uploads";
        }

        public async Task<string> UploadImageAsync(IFormFile file, string folder)
        {
            // اعتبارسنجی نوع فایل
            var allowedTypes = new[] { "image/jpeg", "image/png", "image/gif" };
            if (!allowedTypes.Contains(file.ContentType))
                throw new InvalidOperationException("Only image files are allowed.");

            return await UploadFileAsync(file, folder);
        }

        public async Task<string> UploadDocumentAsync(IFormFile file, string folder)
        {
            // اعتبارسنجی نوع فایل
            var allowedTypes = new[] { "application/pdf", "application/msword", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" };
            if (!allowedTypes.Contains(file.ContentType))
                throw new InvalidOperationException("Only PDF or Word documents are allowed.");

            return await UploadFileAsync(file, folder);
        }

        private async Task<string> UploadFileAsync(IFormFile file, string folder)
        {
            var directory = Path.Combine(_uploadPath, folder);
            Directory.CreateDirectory(directory);

            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var filePath = Path.Combine(directory, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Path.Combine(folder, fileName).Replace("\\", "/");
        }

        public bool DeleteFile(string filePath)
        {
            try
            {
                var fullPath = Path.Combine(_uploadPath, filePath);
                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}