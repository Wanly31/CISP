using CispRazor.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CispRazor.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly StudentContext _db;

        public IndexModel(StudentContext db)
        {
            _db = db;
        }

        public List<Models.Students> Students { get; set; } = new();

        [TempData]
        public string? Error { get; set; }

        public void OnGet()
        {
            Students = _db.Students.OrderBy(s => s.LastName).ToList();
        }

        public IActionResult OnPostDelete(int id)
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
                    Error = "Неможливо видалити студента, у якого є оцінки.";
                }
            }
            return RedirectToPage();
        }
    }
}
