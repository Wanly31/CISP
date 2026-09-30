using CispMVC.Data;
using CispMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CispMVC.Controllers
{
    public class GradesController : Controller
    {
        private readonly StudentContext _db;

        public GradesController(StudentContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var grades = _db.Grades
                .Include(g => g.Student)
                .Include(g => g.Subject)
                .OrderByDescending(g => g.ExamDate)
                .ToList();
            return View(grades);
        }

        public IActionResult Create()
        {
            FillLists();
            return View("Form", new Grades());
        }

        public IActionResult Edit(int id)
        {
            var grade = _db.Grades.Find(id);
            if (grade == null) return NotFound();
            FillLists();
            return View("Form", grade);
        }

        [HttpPost]
        public IActionResult Save(Grades model)
        {
            if (!ModelState.IsValid)
            {
                FillLists();
                return View("Form", model);
            }

            if (model.Id == 0) _db.Grades.Add(model);
            else _db.Grades.Update(model);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var grade = _db.Grades.Find(id);
            if (grade != null)
            {
                _db.Grades.Remove(grade);
                _db.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        private void FillLists()
        {
            var students = _db.Students.OrderBy(s => s.LastName)
                .Select(s => new { s.Id, Name = s.LastName + " " + s.FirstName })
                .ToList();
            ViewBag.Students = new SelectList(students, "Id", "Name");
            ViewBag.Subjects = new SelectList(_db.Subjects.OrderBy(s => s.SubjectName).ToList(), "Id", "SubjectName");
        }
    }
}
