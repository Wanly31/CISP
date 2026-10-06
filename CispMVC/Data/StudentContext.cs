using CispMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CispMVC.Data
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> dbContextOptions) : base(dbContextOptions)
        {

        }


        public DbSet<Students> Students { get; set; }
        public DbSet<Grades> Grades { get; set; }
        public DbSet<Subjects> Subjects { get; set; }
        public DbSet<Teachers> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Students>().ToTable("Students");
            modelBuilder.Entity<Students>().Property(e => e.Id).HasColumnName("StudentID");
            modelBuilder.Entity<Students>().Property(e => e.Scholarship).HasPrecision(10, 2);

            modelBuilder.Entity<Teachers>().ToTable("Teachers");
            modelBuilder.Entity<Teachers>().Property(e => e.Id).HasColumnName("TeacherID");

            modelBuilder.Entity<Subjects>().ToTable("Subjects");
            modelBuilder.Entity<Subjects>().Property(e => e.Id).HasColumnName("SubjectID");
            modelBuilder.Entity<Subjects>()
                .HasOne(s => s.Teacher)
                .WithMany()
                .HasForeignKey(s => s.TeacherId);

            modelBuilder.Entity<Grades>().ToTable("Grades");
            modelBuilder.Entity<Grades>().Property(e => e.Id).HasColumnName("GradeID");
            modelBuilder.Entity<Grades>()
                .HasOne(g => g.Student)
                .WithMany()
                .HasForeignKey(g => g.StudentId);
            modelBuilder.Entity<Grades>()
                .HasOne(g => g.Subject)
                .WithMany()
                .HasForeignKey(g => g.SubjectId);
        }
    }
}
