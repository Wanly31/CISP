using CispRazor.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CispRazor.Pages.Students
{
    public class EditModel : PageModel
    {
        private readonly StudentContext _db;

        public EditModel(StudentContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Models.Students Student { get; set; } = new();

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                Student = new Models.Students { BirthDate = new DateTime(2005, 1, 1) };
                return Page();
            }

            var student = _db.Students.Find(id);
            if (student == null) return NotFound();
            Student = student;
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();

            if (Student.Id == 0) _db.Students.Add(Student);
            else _db.Students.Update(Student);
            _db.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}
