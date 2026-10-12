using CispRazor.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CispRazor.Pages.Grades
{
    public class EditModel : PageModel
    {
        private readonly StudentContext _db;

        public EditModel(StudentContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Models.Grades Grade { get; set; } = new();

        public SelectList Students { get; set; } = null!;
        public SelectList Subjects { get; set; } = null!;

        public IActionResult OnGet(int? id)
        {
            if (id != null)
            {
                var grade = _db.Grades.Find(id);
                if (grade == null) return NotFound();
                Grade = grade;
            }

            FillLists();
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                FillLists();
                return Page();
            }

            if (Grade.Id == 0) _db.Grades.Add(Grade);
            else _db.Grades.Update(Grade);
            _db.SaveChanges();
            return RedirectToPage("Index");
        }

        private void FillLists()
        {
            var students = _db.Students.OrderBy(s => s.LastName)
                .Select(s => new { s.Id, Name = s.LastName + " " + s.FirstName })
                .ToList();
            Students = new SelectList(students, "Id", "Name");
            Subjects = new SelectList(_db.Subjects.OrderBy(s => s.SubjectName).ToList(), "Id", "SubjectName");
        }
    }
}
