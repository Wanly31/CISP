
using System.ComponentModel.DataAnnotations;

namespace CispBlazor.Models
{
    public class Teachers
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;
        public string? MiddleName { get; set; }
    }
}
