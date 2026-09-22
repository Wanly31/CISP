
namespace Cisp.Models
{
    public class Subjects
    {
        public int Id { get; set; }
        public string SubjectName { get; set; }

        public Teachers Teacher { get; set; }
    }
}
