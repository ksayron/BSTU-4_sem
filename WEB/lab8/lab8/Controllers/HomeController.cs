using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;
using lab6_MSSQL_LIB;

using lab8.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;

namespace lab8.Controllers
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
        #region Index
        [HttpGet]
        public IActionResult Index()
        {
            return View(this.repo);
        }
        [HttpPut]
        public IActionResult Index(int cel_id,Celebrity celebrity)
        {
            this.repo.UpdCelebrity(cel_id,celebrity);
            return View(this.repo);
        }
        [HttpDelete]
        public IActionResult Index(Celebrity celebrity)
        {
     
            return View(this.repo);
        }
        #endregion
        #region CelForm
        [HttpGet]
        public IActionResult Form()
        {

            var viewModel = new NewCelebrityViewModel
            {
                Countries = LoadCountriesFromJson()
            };
            return View(viewModel);
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
        #endregion
        #region Confirm
        public IActionResult Confirm(int id)
        {
            return View(repo.GetCelebById(id));
        }
        [HttpPost]
        public async Task<IActionResult> Confirm(NewCelebrityViewModel model)
        {

            var celebrity = new Celebrity();
           if (model.UploadedFile is not null){

                var filePath = await _fileUploadService.UploadFileAsync(model.UploadedFile);
                celebrity.FullName = model.FullName;
                celebrity.Nationality = model.Nationality;
                celebrity.ReqPhotoPath = filePath;

            }
            else
            {
                celebrity.FullName = model.FullName;
                celebrity.Nationality = model.Nationality;
                celebrity.ReqPhotoPath = model.ReqPhotoPath;
            }

 
            var result = new CelebrityWithFile
            {
                celebrity = celebrity,
                File = model.UploadedFile
            };

            return View(result);
        }
        #endregion
        #region Delete
        public IActionResult ConfirmDel(int id)
        {

            var celebrity = repo.GetCelebById(id);
            if (celebrity == null)
                return NotFound();
            var cel = new CelebrityWithFile()
            {
                celebrity = celebrity,
            };

            return View(cel);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteCel(int id)
        {

            var existingCelebrity = repo.GetCelebById(id);
            if (existingCelebrity == null)
            {
                return NotFound();
            }

            

            if (!repo.DelCelebrity(id))
            {
                return BadRequest($"Failed to delete cel with id:{id}.");
            }

            return RedirectToAction("Index");
        }

        #endregion
        #region Edit
        public IActionResult EditCelebrity(int id)
        {
            var celeb = repo.GetCelebById(id);
            var viewModel = new NewCelebrityViewModel
            {
                Id = id,
                FullName = celeb.FullName,
                Nationality = celeb.Nationality,
                ReqPhotoPath = celeb.ReqPhotoPath,
                Countries = LoadCountriesFromJson()
            };

            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> EditCelebrity(int id, NewCelebrityViewModel model)
        {

            var existingCelebrity = repo.GetCelebById(id);
            if (existingCelebrity == null)
            {
                return NotFound();
            }

            string photoPath = model.ReqPhotoPath;

            if (model.UploadedFile != null)
            {
                photoPath = await _fileUploadService.UploadFileAsync(model.UploadedFile);
            }

            var updatedCelebrity = new Celebrity
            {
                Id = id,
                FullName = model.FullName,
                Nationality = model.Nationality,
                ReqPhotoPath = photoPath
            };

            if (!repo.UpdCelebrity(id, updatedCelebrity))
            {
                return BadRequest("Update failed.");
            }

            return RedirectToAction("Index");
        }

        #endregion


        [WikipediaReferencesFilter]
        [HttpGet("/api/Celebrities/{id}")]
        public IActionResult Celebrity(int id)
        {
            var celebrity = repo.GetCelebById(id);
            if (celebrity == null)
                return NotFound();
            ViewData["CountryLabel"] = GetCountryLabel(celebrity.Nationality);
            return View(celebrity);
        }


        #region ErrorHandler
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #endregion

        #region CountryMethods

        private List<SelectListItem> LoadCountriesFromJson(string jsonPath= "D:\\BSTU\\4sem\\WEB\\lab8\\lab8\\wwwroot\\Country_Codes.json")
        {
            var json = System.IO.File.ReadAllText(jsonPath);
            var countries = JsonSerializer.Deserialize<List<Country>>(json);
            return countries.Select(c => new SelectListItem
            {
                Text = c.CountryLabel,
                Value = c.Code
            }).ToList();
        }
        private string GetCountryLabel(string code)
        {
            //var jsonConfig = JsonSerializer.Deserialize<Dictionary<string, string>>(System.IO.File.ReadAllText("Celebrities.config.json"));
            //var countryPath = jsonConfig["CountryCodes"];
            var json = System.IO.File.ReadAllText("D:\\BSTU\\4sem\\WEB\\lab8\\lab8\\wwwroot\\Country_Codes.json");

            var countries = JsonSerializer.Deserialize<List<Country>>(json);

            return countries
                .FirstOrDefault(c => string.Equals(c.Code, code, StringComparison.OrdinalIgnoreCase))
                ?.CountryLabel ?? code;
        }
        #endregion

    }
}
