using CispMVC.Data;
using CispMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CispMVC.Controllers
{
    public class SubjectsController : Controller
    {
        private readonly StudentContext _db;

        public SubjectsController(StudentContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.Subjects.Include(s => s.Teacher).OrderBy(s => s.SubjectName).ToList());
        }

        public IActionResult Create()
        {
            FillTeachers();
            return View("Form", new Subjects());
        }

        public IActionResult Edit(int id)
        {
            var subject = _db.Subjects.Find(id);
            if (subject == null) return NotFound();
            FillTeachers();
            return View("Form", subject);
        }

        [HttpPost]
        public IActionResult Save(Subjects subject)
        {
            if (!ModelState.IsValid)
            {
                FillTeachers();
                return View("Form", subject);
            }

            if (subject.Id == 0) _db.Subjects.Add(subject);
            else _db.Subjects.Update(subject);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var subject = _db.Subjects.Find(id);
            if (subject != null)
            {
                try
                {
                    _db.Subjects.Remove(subject);
                    _db.SaveChanges();
                }
                catch (DbUpdateException)
                {
                    TempData["Error"] = "Неможливо видалити предмет, з якого є оцінки.";
                }
            }
            return RedirectToAction(nameof(Index));
        }

        private void FillTeachers()
        {
            var teachers = _db.Teachers.OrderBy(t => t.LastName)
                .Select(t => new { t.Id, Name = t.LastName + " " + t.FirstName })
                .ToList();
            ViewBag.Teachers = new SelectList(teachers, "Id", "Name");
        }
    }
}
