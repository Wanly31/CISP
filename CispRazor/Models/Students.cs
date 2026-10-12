using System;
using System.ComponentModel.DataAnnotations;

namespace CispRazor.Models
{
    public class Students
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public decimal Scholarship { get; set; }


    }
}
