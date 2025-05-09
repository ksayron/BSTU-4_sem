using System.Diagnostics;
using lab7.Models;
using Microsoft.AspNetCore.Mvc;
using lab6_MSSQL_LIB;

namespace lab7.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IRepository repo;

        public HomeController(IRepository repo) : base()
        {

            this.repo = repo;

        }

        public IActionResult Index()
        {
            return View(this.repo);
        }

        //public IActionResult Index(IRepository repository)
        //{
        //    return View(repository);
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
