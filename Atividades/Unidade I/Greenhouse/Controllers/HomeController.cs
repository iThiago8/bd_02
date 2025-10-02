using System.Diagnostics;
using Greenhouse.Interfaces;
using Greenhouse.Models;
using Microsoft.AspNetCore.Mvc;

namespace Greenhouse.Controllers
{
    public class HomeController(IPlantRepository plantRepository, ILogger<HomeController> logger) : Controller
    {

        public IActionResult Index()
        {
            ViewBag.TotalPlants = plantRepository.Count();
            return View();
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
