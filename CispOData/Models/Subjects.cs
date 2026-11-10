namespace CispOData.Models
{
    public class Subjects
    {
        public int Id { get; set; }
        public string SubjectName { get; set; } = null!;

        public int TeacherId { get; set; }
        public Teachers? Teacher { get; set; }
    }
}
