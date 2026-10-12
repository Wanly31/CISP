using CispRazor.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CispRazor.Pages.Teachers
{
    public class IndexModel : PageModel
    {
        private readonly StudentContext _db;

        public IndexModel(StudentContext db)
        {
            _db = db;
        }

        public List<Models.Teachers> Teachers { get; set; } = new();

        [TempData]
        public string? Error { get; set; }

        public void OnGet()
        {
            Teachers = _db.Teachers.OrderBy(t => t.LastName).ToList();
        }

        public IActionResult OnPostDelete(int id)
        {
            var teacher = _db.Teachers.Find(id);
            if (teacher != null)
            {
                try
                {
                    _db.Teachers.Remove(teacher);
                    _db.SaveChanges();
                }
                catch (DbUpdateException)
                {
                    Error = "Неможливо видалити викладача, який веде предмети.";
                }
            }
            return RedirectToPage();
        }
    }
}
