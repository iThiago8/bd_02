using System.Diagnostics;
using System.Threading.Tasks;
using EFTest.Data;
using EFTest.Interfaces;
using EFTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFTest.Controllers
{
    public class StudentController : Controller
    {
        private readonly ILogger<StudentController> _logger;
        private readonly IStudentRepository _studentRepository;

        public StudentController(
            ILogger<StudentController> logger,
            IStudentRepository studentRepository

        )
        {
            _logger = logger;
            _studentRepository = studentRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            if (ModelState.IsValid)
            {
                await _studentRepository.Create(student);
                return RedirectToAction("StudentTable");
            }

            return View(student);
        }


        [HttpGet]
        public async Task<IActionResult> StudentTable()
        {
            return View(await _studentRepository.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var student = await _studentRepository.GetById(id);
            if (student == null)
                return NotFound();

            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Student student)
        {
            if (ModelState.IsValid)
            {
                await _studentRepository.Update(student);
                return RedirectToAction("Index");
            }

            return View(student);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _studentRepository.GetById(id);
            if (student == null)
                return NotFound();

            await _studentRepository.Delete(student);
            return RedirectToAction("Index");
        }

    }
}
