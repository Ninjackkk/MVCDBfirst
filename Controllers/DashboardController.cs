using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MVCDBFirst.Controllers
{
    [Authorize]
    [ResponseCache(Location =ResponseCacheLocation.None,NoStore=true)]
    public class DashboardController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Home()
        {
            return View();
        }
    }
}
