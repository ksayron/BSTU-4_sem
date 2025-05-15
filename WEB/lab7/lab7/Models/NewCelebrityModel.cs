namespace lab7.Models
{
    using lab6_MSSQL_LIB;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using System.IO;
    using System.Threading.Tasks;
    public class NewCelebrityModel : PageModel
    {
        public Celebrity celebrity;
        public string Message;
        private readonly ILogger<NewCelebrityModel> _logger;
        private readonly IWebHostEnvironment _environment;

        [BindProperty]
        public IFormFile UploadedFile { get; set; }

        public NewCelebrityModel( IWebHostEnvironment environment)
        {

            _environment = environment;
        }

        public void OnGet()
        {
        }

        public async Task OnPostAsync()
        {
            if (UploadedFile == null || UploadedFile.Length == 0)
            {
                return;
            }

            _logger.LogInformation($"Uploading {UploadedFile.FileName}.");
           
            string targetFileName = $"{this._environment.WebRootPath}/{UploadedFile.FileName}";

            using (var stream = new FileStream(targetFileName, FileMode.Create))
            {
                await UploadedFile.CopyToAsync(stream);
                this.Message = string.Format("<b>{0}<b> uploaded",targetFileName);
            }
        }
    }

}
