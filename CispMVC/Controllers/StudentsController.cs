using CispMVC.Data;
using CispMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CispMVC.Controllers
{
    public class StudentsController : Controller
    {
        private readonly StudentContext _db;

        public StudentsController(StudentContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.Students.OrderBy(s => s.LastName).ToList());
        }

        public IActionResult Create()
        {
            return View("Form", new Students { BirthDate = new DateTime(2005, 1, 1) });
        }

        public IActionResult Edit(int id)
        {
            var student = _db.Students.Find(id);
            if (student == null) return NotFound();
            return View("Form", student);
        }

        [HttpPost]
        public IActionResult Save(Students student)
        {
            if (!ModelState.IsValid) return View("Form", student);

            if (student.Id == 0) _db.Students.Add(student);
            else _db.Students.Update(student);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var student = _db.Students.Find(id);
            if (student != null)
            {
                try
                {
                    _db.Students.Remove(student);
                    _db.SaveChanges();
                }
                catch (DbUpdateException)
                {
                    TempData["Error"] = "Неможливо видалити студента, у якого є оцінки.";
                }
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
