using System.Diagnostics;
using lab7.Models;
using Microsoft.AspNetCore.Mvc;
using lab6_MSSQL_LIB;
using lab7.Models;

namespace lab7.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IRepository repo;
        private readonly IFileUploadService _fileUploadService;

        public HomeController(IRepository repo,IFileUploadService fileUploadService) : base()
        {

            this.repo = repo;
            this._fileUploadService = fileUploadService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(this.repo);
        }
        [HttpGet]
        public IActionResult Form()
        {
            return View(new NewCelebrityViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Form(NewCelebrityViewModel model)
        {
            if (ModelState.IsValid)
            {
                var filePath = await _fileUploadService.UploadFileAsync(model.UploadedFile);
                model.Message = $"Файл загружен: {Path.GetFileName(filePath)}";
            }

            return View(model);
        }

        [HttpGet("/api/Celebrities/{id}")]
        public IActionResult Celebrity(int id)
        {
            var celebrity = repo.GetCelebById(id);
            if (celebrity == null)
                return NotFound();

            return View(celebrity);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
