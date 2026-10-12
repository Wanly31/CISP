using CispRazor.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CispRazor.Pages.Subjects
{
    public class IndexModel : PageModel
    {
        private readonly StudentContext _db;

        public IndexModel(StudentContext db)
        {
            _db = db;
        }

        public List<Models.Subjects> Subjects { get; set; } = new();

        [TempData]
        public string? Error { get; set; }

        public void OnGet()
        {
            Subjects = _db.Subjects.Include(s => s.Teacher).OrderBy(s => s.SubjectName).ToList();
        }

        public IActionResult OnPostDelete(int id)
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
                    Error = "Неможливо видалити предмет, з якого є оцінки.";
                }
            }
            return RedirectToPage();
        }
    }
}
