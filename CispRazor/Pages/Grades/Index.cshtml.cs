using CispRazor.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CispRazor.Pages.Grades
{
    public class IndexModel : PageModel
    {
        private readonly StudentContext _db;

        public IndexModel(StudentContext db)
        {
            _db = db;
        }

        public List<Models.Grades> Grades { get; set; } = new();

        public void OnGet()
        {
            Grades = _db.Grades
                .Include(g => g.Student)
                .Include(g => g.Subject)
                .OrderByDescending(g => g.ExamDate)
                .ToList();
        }

        public IActionResult OnPostDelete(int id)
        {
            var grade = _db.Grades.Find(id);
            if (grade != null)
            {
                _db.Grades.Remove(grade);
                _db.SaveChanges();
            }
            return RedirectToPage();
        }
    }
}
