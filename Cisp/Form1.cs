using Cisp.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Cisp
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadStudents();
            LoadTeachers();
            LoadSubjects();
            LoadGrades();
            LoadReport();
        }

        private void LoadStudents()
        {
            SetupColumns(lstStudents,
    ("ID", 40), ("Last Name", 100), ("First Name", 100), ("Middle Name", 100),
    ("Address", 180), ("Phone", 100), ("Birth Date", 90), ("Scholarship", 90));

            using (var db = new StudentContext())

            {

                var students = db.Students.OrderBy(x => x.LastName).ToList();
                lstStudents.Items.Clear();

                foreach (var student in students)
                {
                    ListViewItem item = new ListViewItem(student.Id.ToString());
                    item.SubItems.Add(student.LastName.ToString());
                    item.SubItems.Add(student.FirstName.ToString());
                    item.SubItems.Add(student.MiddleName.ToString());
                    item.SubItems.Add(student.Address.ToString());
                    item.SubItems.Add(student.Phone.ToString());
                    item.SubItems.Add(student.BirthDate.ToString("dd.MM.yyyy"));

                    decimal scholarship = Convert.ToDecimal(student.Scholarship);
                    item.SubItems.Add(scholarship.ToString("N2"));
                    if (scholarship == 0)
                        item.ForeColor = Color.Gray;

                    lstStudents.Items.Add(item);
                }
            }
        }


        private void LoadTeachers()
        {
            SetupColumns(lstTeachers,
                ("ID", 40), ("Last Name", 120), ("First Name", 120), ("Middle Name", 120));



            using (var db = new StudentContext())
            {
                var teachers = db.Teachers.OrderBy(x => x.LastName).ToList();
                lstTeachers.Items.Clear();

                foreach (var teacher in teachers)
                {
                    ListViewItem item = new ListViewItem(teacher.Id.ToString());
                    item.SubItems.Add(teacher.LastName.ToString());
                    item.SubItems.Add(teacher.FirstName.ToString());
                    item.SubItems.Add(teacher.MiddleName.ToString());
                    lstTeachers.Items.Add(item);
                }
            }
        }


        private void LoadSubjects()
        {
            SetupColumns(lstSubjects,
                ("ID", 40), ("Subject", 180), ("Teacher", 180));


            using (var db = new StudentContext())
            {
                var subjects = db.Subjects.Include(s => s.Teacher).ToList();

                lstSubjects.Items.Clear();

                foreach (var subject in subjects)
                {
                    ListViewItem item = new ListViewItem(subject.Id.ToString());
                    item.SubItems.Add(subject.SubjectName.ToString());
                    item.SubItems.Add(subject.Teacher.LastName + " " + subject.Teacher.FirstName);
                    lstSubjects.Items.Add(item);
                }
            }

        }


        private void LoadGrades()
        {
            SetupColumns(lstGrades,
                ("ID", 40), ("Student", 160), ("Subject", 140), ("Exam Date", 90), ("Grade", 60));

            using (var db = new StudentContext())
            {
                var grades = db.Grades.
                    Include(s => s.Student).
                    Include(x => x.Subject).
                    OrderBy(o => o.Id).
                    ToList();

                lstGrades.Items.Clear();

                foreach (var grade in grades)
                {
                    ListViewItem item = new ListViewItem(grade.Id.ToString());
                    item.SubItems.Add(grade.Student.LastName + " " + grade.Student.FirstName.ToString());
                    item.SubItems.Add(grade.Subject.ToString());
                    item.SubItems.Add(grade.ExamDate.ToString("dd.MM.yyyy"));

                    int grade1 = Convert.ToInt32(grade.Grade);
                    item.SubItems.Add(grade1.ToString());

                    if (grade1 <= 2)
                        item.ForeColor = Color.Red;
                    else if (grade1 == 5)
                        item.ForeColor = Color.Green;

                    lstGrades.Items.Add(item);
                }
            }




        }
        private void LoadReport()
        {
            SetupColumns(lstReport,
                ("Student", 160), ("Subject", 140), ("Exam Date", 90),
                ("Grade", 60), ("Teacher", 160), ("Scholarship", 90));

            using (var db = new StudentContext())
            {
                var grades = db.Grades
                    .Include(g => g.Student)
                    .Include(g => g.Subject)
                        .ThenInclude(s => s.Teacher)
                    .OrderBy(g => g.Student.LastName)
                    .ToList();

                lstReport.Items.Clear();

                foreach (var grade in grades)
                {
                    string studentFullName = grade.Student.LastName + " " + grade.Student.FirstName;
                    string teacherFullName = grade.Subject.Teacher.LastName + " " + grade.Subject.Teacher.FirstName;

                    ListViewItem item = new ListViewItem(studentFullName);
                    item.SubItems.Add(grade.Subject.SubjectName);
                    item.SubItems.Add(grade.ExamDate.ToString("dd.MM.yyyy"));
                    item.SubItems.Add(grade.Grade.ToString());
                    item.SubItems.Add(teacherFullName);
                    item.SubItems.Add(grade.Student.Scholarship.ToString("N2"));
                    lstReport.Items.Add(item);
                }
            }
        }


        private void SetupColumns(ListView listView, params (string Title, int Width)[] columns)
        {
            listView.View = View.Details;
            listView.FullRowSelect = true;
            listView.GridLines = true;
            listView.Columns.Clear();

            foreach (var col in columns)
                listView.Columns.Add(col.Title, col.Width);
        }
    }
}