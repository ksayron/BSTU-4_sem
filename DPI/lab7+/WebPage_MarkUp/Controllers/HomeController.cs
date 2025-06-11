using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebPage_MarkUp.Models;

namespace WebPage_MarkUp.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly ILogger<HomeController> _logger;
        private CatalogViewModel _catalog;
        private BookDetailsViewModel _book;
       
        public HomeController(CatalogViewModel catalog,BookDetailsViewModel book)
        {
            _catalog = catalog;
            _book = book;
   
        }
        public IActionResult Index()
        {
            return View(_catalog);
        }
        public IActionResult Book()
        {
            return View(_book);
        }

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
