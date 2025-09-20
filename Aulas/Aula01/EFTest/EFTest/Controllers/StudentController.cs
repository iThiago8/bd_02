using System.Diagnostics;
using System.Threading.Tasks;
using EFTest.Data;
using EFTest.Interfaces;
using EFTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFTest.Controllers
{
    public class StudentController(IStudentRepository studentRepository) : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            if (ModelState.IsValid)
            {
                await studentRepository.Create(student);
                return RedirectToAction("Index");
            }

            return View(student);
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await studentRepository.GetAll());
        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var student = await studentRepository.GetById(id);
            if (student == null)
                return NotFound();
            else
                return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int? id, Student student)
        {
            if (!id.HasValue)
                return BadRequest();

            if (id.Value != student.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                await studentRepository.Update(student);
                return RedirectToAction("Index");
            }

            return View(student);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await studentRepository.GetById(id);
            if (student == null)
                return NotFound();

            await studentRepository.Delete(student);
            return RedirectToAction("Index");
        }

    }
}
