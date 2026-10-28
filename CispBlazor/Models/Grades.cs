using System.ComponentModel.DataAnnotations;

namespace CispBlazor.Models
{
    public class Grades
    {
        public int Id { get; set; }
        public DateTime ExamDate { get; set; } = DateTime.Today;
        [Range(1, 5, ErrorMessage = "Оцінка має бути від 1 до 5")]
        public int Grade { get; set; } = 5;
        public int StudentId { get; set; }
        public Students? Student { get; set; }
        public int SubjectId { get; set; }
        public Subjects? Subject { get; set; }
    }
}
