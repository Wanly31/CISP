namespace CispOData.Models
{
    public class Grades
    {
        public int Id { get; set; }
        public DateTime ExamDate { get; set; }
        public int Grade { get; set; }

        public int StudentId { get; set; }
        public Students? Student { get; set; }

        public int SubjectId { get; set; }
        public Subjects? Subject { get; set; }
    }
}
