using System.ComponentModel.DataAnnotations;

namespace CispMVC.Models
{
    public class Subjects
    {
        public int Id { get; set; }
        [Required]
        public string SubjectName { get; set; } = null!;
        public int TeacherId { get; set; }
        public Teachers? Teacher { get; set; }
    }
}
