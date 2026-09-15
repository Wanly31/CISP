using System;
using System.Windows.Forms;
using System.Configuration;
using Microsoft.Data.SqlClient;
using System.Drawing;

namespace Cisp
{
    public partial class Form1 : Form
    {
        private readonly string connectionString =
            ConfigurationManager.ConnectionStrings["ConnectString"].ConnectionString;

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

            string sql = @"SELECT StudentID, LastName, FirstName, MiddleName,
                                   Address, Phone, BirthDate, Scholarship
                            FROM Students
                            ORDER BY LastName";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    lstStudents.Items.Clear();
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["StudentID"].ToString());
                        item.SubItems.Add(reader["LastName"].ToString());
                        item.SubItems.Add(reader["FirstName"].ToString());
                        item.SubItems.Add(reader["MiddleName"].ToString());
                        item.SubItems.Add(reader["Address"].ToString());
                        item.SubItems.Add(reader["Phone"].ToString());
                        item.SubItems.Add(Convert.ToDateTime(reader["BirthDate"]).ToString("dd.MM.yyyy"));

                        decimal scholarship = Convert.ToDecimal(reader["Scholarship"]);
                        item.SubItems.Add(scholarship.ToString("N2"));
                        if (scholarship == 0)
                            item.ForeColor = Color.Gray;

                        lstStudents.Items.Add(item);
                    }
                }
            }
        }

        private void LoadTeachers()
        {
            SetupColumns(lstTeachers,
                ("ID", 40), ("Last Name", 120), ("First Name", 120), ("Middle Name", 120));

            string sql = @"SELECT TeacherID, LastName, FirstName, MiddleName
                            FROM Teachers
                            ORDER BY LastName";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    lstTeachers.Items.Clear();
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["TeacherID"].ToString());
                        item.SubItems.Add(reader["LastName"].ToString());
                        item.SubItems.Add(reader["FirstName"].ToString());
                        item.SubItems.Add(reader["MiddleName"].ToString());
                        lstTeachers.Items.Add(item);
                    }
                }
            }
        }


        private void LoadSubjects()
        {
            SetupColumns(lstSubjects,
                ("ID", 40), ("Subject", 180), ("Teacher", 180));

            string sql = @"SELECT sub.SubjectID, sub.SubjectName,
                                   t.LastName + ' ' + t.FirstName AS TeacherFullName
                            FROM Subjects sub
                            JOIN Teachers t ON sub.TeacherID = t.TeacherID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    lstSubjects.Items.Clear();
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["SubjectID"].ToString());
                        item.SubItems.Add(reader["SubjectName"].ToString());
                        item.SubItems.Add(reader["TeacherFullName"].ToString());
                        lstSubjects.Items.Add(item);
                    }
                }
            }
        }


        private void LoadGrades()
        {
            SetupColumns(lstGrades,
                ("ID", 40), ("Student", 160), ("Subject", 140), ("Exam Date", 90), ("Grade", 60));

            string sql = @"SELECT g.GradeID,
                                   s.LastName + ' ' + s.FirstName AS StudentFullName,
                                   sub.SubjectName,
                                   g.ExamDate,
                                   g.Grade
                            FROM Grades g
                            JOIN Students s ON g.StudentID = s.StudentID
                            JOIN Subjects sub ON g.SubjectID = sub.SubjectID
                            ORDER BY s.LastName, g.ExamDate";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    lstGrades.Items.Clear();
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["GradeID"].ToString());
                        item.SubItems.Add(reader["StudentFullName"].ToString());
                        item.SubItems.Add(reader["SubjectName"].ToString());
                        item.SubItems.Add(Convert.ToDateTime(reader["ExamDate"]).ToString("dd.MM.yyyy"));

                        int grade = Convert.ToInt32(reader["Grade"]);
                        item.SubItems.Add(grade.ToString());

                        if (grade <= 2)
                            item.ForeColor = Color.Red;
                        else if (grade == 5)
                            item.ForeColor = Color.Green;

                        lstGrades.Items.Add(item);
                    }
                }
            }
        }

        private void LoadReport()
        {
            SetupColumns(lstReport,
                ("Student", 160), ("Subject", 140), ("Exam Date", 90),
                ("Grade", 60), ("Teacher", 160), ("Scholarship", 90));

            string sql = @"SELECT s.LastName + ' ' + s.FirstName AS StudentFullName,
                                   sub.SubjectName,
                                   g.ExamDate,
                                   g.Grade,
                                   t.LastName + ' ' + t.FirstName AS TeacherFullName,
                                   s.Scholarship
                            FROM Grades g
                            JOIN Students s ON g.StudentID = s.StudentID
                            JOIN Subjects sub ON g.SubjectID = sub.SubjectID
                            JOIN Teachers t ON sub.TeacherID = t.TeacherID
                            ORDER BY s.LastName";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    lstReport.Items.Clear();
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["StudentFullName"].ToString());
                        item.SubItems.Add(reader["SubjectName"].ToString());
                        item.SubItems.Add(Convert.ToDateTime(reader["ExamDate"]).ToString("dd.MM.yyyy"));
                        item.SubItems.Add(reader["Grade"].ToString());
                        item.SubItems.Add(reader["TeacherFullName"].ToString());
                        item.SubItems.Add(Convert.ToDecimal(reader["Scholarship"]).ToString("N2"));
                        lstReport.Items.Add(item);
                    }
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