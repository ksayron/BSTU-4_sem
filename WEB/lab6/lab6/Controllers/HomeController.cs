using lab6_MSSQL_LIB;
using Microsoft.AspNetCore.Mvc;

namespace lab6.Controllers
{
    public class HomeController : Controller
    {
        private IRepository repo;
        public HomeController(IRepository repo) : base()
        {

            this.repo = repo;

        }

        public IActionResult Index()
        {

            return View(this.repo);
        }
    }
}
