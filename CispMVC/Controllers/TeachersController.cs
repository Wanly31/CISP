using CispMVC.Data;
using CispMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CispMVC.Controllers
{
    public class TeachersController : Controller
    {
        private readonly StudentContext _db;

        public TeachersController(StudentContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.Teachers.OrderBy(t => t.LastName).ToList());
        }

        public IActionResult Create()
        {
            return View("Form", new Teachers());
        }

        public IActionResult Edit(int id)
        {
            var teacher = _db.Teachers.Find(id);
            if (teacher == null) return NotFound();
            return View("Form", teacher);
        }

        [HttpPost]
        public IActionResult Save(Teachers teacher)
        {
            if (!ModelState.IsValid) return View("Form", teacher);

            if (teacher.Id == 0) _db.Teachers.Add(teacher);
            else _db.Teachers.Update(teacher);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var teacher = _db.Teachers.Find(id);
            if (teacher != null)
            {
                try
                {
                    _db.Teachers.Remove(teacher);
                    _db.SaveChanges();
                }
                catch (DbUpdateException)
                {
                    TempData["Error"] = "Неможливо видалити викладача, який веде предмети.";
                }
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
