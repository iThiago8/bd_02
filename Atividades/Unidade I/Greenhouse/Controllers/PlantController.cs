using Greenhouse.Interfaces;
using Greenhouse.Models;
using Microsoft.AspNetCore.Mvc;

namespace Greenhouse.Controllers
{
    public class PlantController(IPlantRepository plantRepository) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await plantRepository.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Plant plant)
        {
            if (!ModelState.IsValid)
                return View(plant);

            await plantRepository.Create(plant);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var plant = await plantRepository.GetById(id);
            if (plant == null)
                return NotFound();

            await plantRepository.Delete(plant);
            return RedirectToAction("Index");
        }
    }
}
