namespace CispOData.Models
{
    public class Students
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public decimal Scholarship { get; set; }
    }
}
