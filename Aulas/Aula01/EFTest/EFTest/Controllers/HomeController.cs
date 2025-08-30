using System.Diagnostics;
using System.Threading.Tasks;
using EFTest.Data;
using EFTest.Interfaces;
using EFTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStudentRepository _studentRepository;

        public HomeController(
            ILogger<HomeController> logger,
            IStudentRepository studentRepository
            
        )
        {
            _logger = logger;
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> StudentTable()
        {
            return View(await _studentRepository.GetAll());
        }

        public IActionResult Index()
        {
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
