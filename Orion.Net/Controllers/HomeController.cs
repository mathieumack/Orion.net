using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Orion.Net.Models;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;

namespace Orion.Net.Controllers
{
    /// <summary>
    /// Controller of the pages and its content
    /// </summary>
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Orion");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Orion()
        {
            return View(new UserProfileViewModel()
            {
                Name = User.Identity.Name,
            });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
