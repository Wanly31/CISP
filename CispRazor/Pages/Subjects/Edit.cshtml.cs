using CispRazor.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CispRazor.Pages.Subjects
{
    public class EditModel : PageModel
    {
        private readonly StudentContext _db;

        public EditModel(StudentContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Models.Subjects Subject { get; set; } = new();

        public SelectList Teachers { get; set; } = null!;

        public IActionResult OnGet(int? id)
        {
            if (id != null)
            {
                var subject = _db.Subjects.Find(id);
                if (subject == null) return NotFound();
                Subject = subject;
            }

            FillTeachers();
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                FillTeachers();
                return Page();
            }

            if (Subject.Id == 0) _db.Subjects.Add(Subject);
            else _db.Subjects.Update(Subject);
            _db.SaveChanges();
            return RedirectToPage("Index");
        }

        private void FillTeachers()
        {
            var teachers = _db.Teachers.OrderBy(t => t.LastName)
                .Select(t => new { t.Id, Name = t.LastName + " " + t.FirstName })
                .ToList();
            Teachers = new SelectList(teachers, "Id", "Name");
        }
    }
}
