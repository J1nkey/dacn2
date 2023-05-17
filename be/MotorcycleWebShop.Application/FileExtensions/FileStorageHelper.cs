using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;

namespace MotorcycleWebShop.Application.FileExtensions
{
    public interface IFileStorageHelper
    {
        Task<string> SaveFile(IFormFile file);
        string GetFileUrl(string fileName);
        Task<string> SaveFileAsync(Stream mediaBinaryStream, string fileName);
        Task DeleteFileAsync(string fileName);
        string GetFileName(string filePath);
        string GenerateFilePath(string fileName);
        public string GetFileExtension(string filePath);
        public bool IsImageExisted(string fileName);
        public bool IsContentDirectoryExisted();

    }
    public class FileStorageHelper : IFileStorageHelper
    {
        private readonly string _userContentFolder;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";

        public FileStorageHelper(IWebHostEnvironment hostEnvironment)
        {
            _userContentFolder = Path.Combine(hostEnvironment.WebRootPath, USER_CONTENT_FOLDER_NAME);    
        }

        public async Task DeleteFileAsync(string fileName)
        {
            var filePath = Path.Combine(_userContentFolder, fileName);
            if (File.Exists(filePath))
            {
                await Task.Run(() => File.Delete(filePath));
            }
        }

        public string GenerateFilePath(string fileName)
        {
            return $"{USER_CONTENT_FOLDER_NAME}/{fileName}";
        }

        public string GetFileExtension(string filePath)
        {
            return $"{Path.GetExtension(filePath)}";
        }

        public string GetFileName(string filePath)
        {
            return filePath.Substring(_userContentFolder.Length);
        }

        public string GetFileUrl(string fileName)
        {
            return $"{USER_CONTENT_FOLDER_NAME}/{fileName}";
        }

        public bool IsImageExisted(string fileName)
        {
            var fullImagePath = GenerateFilePath(fileName);
            var isExisted = File.Exists(fullImagePath);

            return isExisted;
        }

        public async Task<string> SaveFile(IFormFile file)
        {
            if (!IsContentDirectoryExisted())
            {
                Directory.CreateDirectory(_userContentFolder);
            }

            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName;
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await SaveFileAsync(file.OpenReadStream(), fileName);

            return fileName; throw new NotImplementedException();
        }

        public async Task<string> SaveFileAsync(Stream mediaBinaryStream, string fileName)
        {
            if (!IsContentDirectoryExisted())
            {
                Directory.CreateDirectory(_userContentFolder);
            }

            var filePath = Path.Combine(_userContentFolder, fileName);
            using var fileStream = new FileStream(@$"{filePath}", FileMode.Create);
            await mediaBinaryStream.CopyToAsync(fileStream);

            var fileRelativePath = "\\" + filePath.Substring(_userContentFolder.Length - USER_CONTENT_FOLDER_NAME.Length);

            return fileRelativePath;
        }

        public bool IsContentDirectoryExisted()
        {
            if (Directory.Exists(_userContentFolder))
            {
                return true;
            }
            return false;
        }
    }
}
