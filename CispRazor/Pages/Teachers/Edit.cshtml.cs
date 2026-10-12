using CispRazor.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CispRazor.Pages.Teachers
{
    public class EditModel : PageModel
    {
        private readonly StudentContext _db;

        public EditModel(StudentContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Models.Teachers Teacher { get; set; } = new();

        public IActionResult OnGet(int? id)
        {
            if (id == null) return Page();

            var teacher = _db.Teachers.Find(id);
            if (teacher == null) return NotFound();
            Teacher = teacher;
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();

            if (Teacher.Id == 0) _db.Teachers.Add(Teacher);
            else _db.Teachers.Update(Teacher);
            _db.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}
