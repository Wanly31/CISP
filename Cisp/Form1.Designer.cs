namespace Cisp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabStudents = new System.Windows.Forms.TabPage();
            this.lstStudents = new System.Windows.Forms.ListView();
            this.tabTeachers = new System.Windows.Forms.TabPage();
            this.lstTeachers = new System.Windows.Forms.ListView();
            this.tabSubjects = new System.Windows.Forms.TabPage();
            this.lstSubjects = new System.Windows.Forms.ListView();
            this.tabGrades = new System.Windows.Forms.TabPage();
            this.lstGrades = new System.Windows.Forms.ListView();
            this.tabReport = new System.Windows.Forms.TabPage();
            this.lstReport = new System.Windows.Forms.ListView();
            this.tabControl.SuspendLayout();
            this.tabStudents.SuspendLayout();
            this.tabTeachers.SuspendLayout();
            this.tabSubjects.SuspendLayout();
            this.tabGrades.SuspendLayout();
            this.tabReport.SuspendLayout();
            this.SuspendLayout();

            // tabControl
            this.tabControl.Controls.Add(this.tabStudents);
            this.tabControl.Controls.Add(this.tabTeachers);
            this.tabControl.Controls.Add(this.tabSubjects);
            this.tabControl.Controls.Add(this.tabGrades);
            this.tabControl.Controls.Add(this.tabReport);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1100, 600);
            this.tabControl.TabIndex = 0;

            // tabStudents
            this.tabStudents.Controls.Add(this.lstStudents);
            this.tabStudents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabStudents.Location = new System.Drawing.Point(4, 25);
            this.tabStudents.Name = "tabStudents";
            this.tabStudents.Padding = new System.Windows.Forms.Padding(4);
            this.tabStudents.Size = new System.Drawing.Size(1092, 571);
            this.tabStudents.TabIndex = 0;
            this.tabStudents.Text = "Students";

            // lstStudents
            this.lstStudents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstStudents.FullRowSelect = true;
            this.lstStudents.GridLines = true;
            this.lstStudents.HideSelection = false;
            this.lstStudents.Location = new System.Drawing.Point(4, 4);
            this.lstStudents.Name = "lstStudents";
            this.lstStudents.Size = new System.Drawing.Size(1084, 563);
            this.lstStudents.TabIndex = 0;
            this.lstStudents.UseCompatibleStateImageBehavior = false;
            this.lstStudents.View = System.Windows.Forms.View.Details;

            // tabTeachers
            this.tabTeachers.Controls.Add(this.lstTeachers);
            this.tabTeachers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabTeachers.Location = new System.Drawing.Point(4, 25);
            this.tabTeachers.Name = "tabTeachers";
            this.tabTeachers.Padding = new System.Windows.Forms.Padding(4);
            this.tabTeachers.Size = new System.Drawing.Size(1092, 571);
            this.tabTeachers.TabIndex = 1;
            this.tabTeachers.Text = "Teachers";

            // lstTeachers
            this.lstTeachers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstTeachers.FullRowSelect = true;
            this.lstTeachers.GridLines = true;
            this.lstTeachers.HideSelection = false;
            this.lstTeachers.Location = new System.Drawing.Point(4, 4);
            this.lstTeachers.Name = "lstTeachers";
            this.lstTeachers.Size = new System.Drawing.Size(1084, 563);
            this.lstTeachers.TabIndex = 0;
            this.lstTeachers.UseCompatibleStateImageBehavior = false;
            this.lstTeachers.View = System.Windows.Forms.View.Details;

            // tabSubjects
            this.tabSubjects.Controls.Add(this.lstSubjects);
            this.tabSubjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSubjects.Location = new System.Drawing.Point(4, 25);
            this.tabSubjects.Name = "tabSubjects";
            this.tabSubjects.Padding = new System.Windows.Forms.Padding(4);
            this.tabSubjects.Size = new System.Drawing.Size(1092, 571);
            this.tabSubjects.TabIndex = 2;
            this.tabSubjects.Text = "Subjects";

            // lstSubjects
            this.lstSubjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstSubjects.FullRowSelect = true;
            this.lstSubjects.GridLines = true;
            this.lstSubjects.HideSelection = false;
            this.lstSubjects.Location = new System.Drawing.Point(4, 4);
            this.lstSubjects.Name = "lstSubjects";
            this.lstSubjects.Size = new System.Drawing.Size(1084, 563);
            this.lstSubjects.TabIndex = 0;
            this.lstSubjects.UseCompatibleStateImageBehavior = false;
            this.lstSubjects.View = System.Windows.Forms.View.Details;

            // tabGrades
            this.tabGrades.Controls.Add(this.lstGrades);
            this.tabGrades.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabGrades.Location = new System.Drawing.Point(4, 25);
            this.tabGrades.Name = "tabGrades";
            this.tabGrades.Padding = new System.Windows.Forms.Padding(4);
            this.tabGrades.Size = new System.Drawing.Size(1092, 571);
            this.tabGrades.TabIndex = 3;
            this.tabGrades.Text = "Grades";

            // lstGrades
            this.lstGrades.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstGrades.FullRowSelect = true;
            this.lstGrades.GridLines = true;
            this.lstGrades.HideSelection = false;
            this.lstGrades.Location = new System.Drawing.Point(4, 4);
            this.lstGrades.Name = "lstGrades";
            this.lstGrades.Size = new System.Drawing.Size(1084, 563);
            this.lstGrades.TabIndex = 0;
            this.lstGrades.UseCompatibleStateImageBehavior = false;
            this.lstGrades.View = System.Windows.Forms.View.Details;

            // tabReport
            this.tabReport.Controls.Add(this.lstReport);
            this.tabReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabReport.Location = new System.Drawing.Point(4, 25);
            this.tabReport.Name = "tabReport";
            this.tabReport.Padding = new System.Windows.Forms.Padding(4);
            this.tabReport.Size = new System.Drawing.Size(1092, 571);
            this.tabReport.TabIndex = 4;
            this.tabReport.Text = "Report";

            // lstReport
            this.lstReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstReport.FullRowSelect = true;
            this.lstReport.GridLines = true;
            this.lstReport.HideSelection = false;
            this.lstReport.Location = new System.Drawing.Point(4, 4);
            this.lstReport.Name = "lstReport";
            this.lstReport.Size = new System.Drawing.Size(1084, 563);
            this.lstReport.TabIndex = 0;
            this.lstReport.UseCompatibleStateImageBehavior = false;
            this.lstReport.View = System.Windows.Forms.View.Details;

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 600);
            this.Controls.Add(this.tabControl);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "Form1";
            this.Text = "Student Performance";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl.ResumeLayout(false);
            this.tabStudents.ResumeLayout(false);
            this.tabTeachers.ResumeLayout(false);
            this.tabSubjects.ResumeLayout(false);
            this.tabGrades.ResumeLayout(false);
            this.tabReport.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabStudents;
        private System.Windows.Forms.TabPage tabTeachers;
        private System.Windows.Forms.TabPage tabSubjects;
        private System.Windows.Forms.TabPage tabGrades;
        private System.Windows.Forms.TabPage tabReport;
        private System.Windows.Forms.ListView lstStudents;
        private System.Windows.Forms.ListView lstTeachers;
        private System.Windows.Forms.ListView lstSubjects;
        private System.Windows.Forms.ListView lstGrades;
        private System.Windows.Forms.ListView lstReport;
    }
}
