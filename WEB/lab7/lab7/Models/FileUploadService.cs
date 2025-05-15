using lab6_MSSQL_LIB;
using System.ComponentModel.DataAnnotations;

namespace lab7.Models
{
    public interface IFileUploadService
    {
        Task<string> UploadFileAsync(IFormFile file);
    }

    public class FileUploadService : IFileUploadService
    {
        private readonly IWebHostEnvironment _env;

        public FileUploadService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task<string> UploadFileAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return null;

            string path = Path.Combine(_env.WebRootPath+"/img", file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return path;
        }
    }
    
    public class NewCelebrityViewModel
    {
        [Required]
        public IFormFile UploadedFile { get; set; }
        public Celebrity NewCelebrity { get; set; }
        public string Message { get; set; }
    }
}
