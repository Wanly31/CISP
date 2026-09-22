using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cisp.Models
{
    public class Grades
    {
        public int Id { get; set; }
        public DateTime ExamDate { get; set; }
        public int Grade { get; set; }

        public Students Student { get; set; }

        public Subjects Subject { get; set; }
    }
}
