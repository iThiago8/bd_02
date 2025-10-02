using Greenhouse.Interfaces;
using Greenhouse.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

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

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var plant = await plantRepository.GetById(id);
            if (plant == null)
                return NotFound();
            else
                return View(plant);
        }

        [HttpPost] 
        public async Task<IActionResult> Update(Plant plant)
        {
            if (!ModelState.IsValid)
                return View(plant);

            await plantRepository.Update(plant);
         
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
