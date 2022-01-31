using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Orion.Net.Models;

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

            return View(new UserProfileModel()
            {
                Name = "The best one",
            });
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View(new UserProfileModel()
            {
                Name = "The best one",
            });
        }

        public IActionResult Privacy()
        {
            return View(new UserProfileModel()
            {
                Name = "The best one",
            });
        }

        public IActionResult Orion()
        {
            return View(new UserProfileModel()
            {
                Name = "The best one",
                SupportID = Guid.NewGuid().ToString(),
            });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
