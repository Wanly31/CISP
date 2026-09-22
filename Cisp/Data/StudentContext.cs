using System;
using System.Configuration;
using Cisp.Models;
using Microsoft.EntityFrameworkCore;

namespace Cisp.Data
{
    public class StudentContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var conn = ConfigurationManager.ConnectionStrings["ConnectString"].ConnectionString;
                optionsBuilder.UseSqlServer(conn);
            }
        }

        public DbSet<Students> Students { get; set; }
        public DbSet<Grades> Grades { get; set; }
        public DbSet<Subjects> Subjects { get; set; }
        public DbSet<Teachers> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Students>().ToTable("Students");
            modelBuilder.Entity<Students>().Property(e => e.Id).HasColumnName("StudentID");

            modelBuilder.Entity<Teachers>().ToTable("Teachers");
            modelBuilder.Entity<Teachers>().Property(e => e.Id).HasColumnName("TeacherID");

            modelBuilder.Entity<Subjects>().ToTable("Subjects");
            modelBuilder.Entity<Subjects>().Property(e => e.Id).HasColumnName("SubjectID");
            modelBuilder.Entity<Subjects>()
                .HasOne(s => s.Teacher)
                .WithMany()
                .HasForeignKey("TeacherID");

            modelBuilder.Entity<Grades>().ToTable("Grades");
            modelBuilder.Entity<Grades>().Property(e => e.Id).HasColumnName("GradeID");
            modelBuilder.Entity<Grades>()
                .HasOne(g => g.Student)
                .WithMany()
                .HasForeignKey("StudentID");
            modelBuilder.Entity<Grades>()
                .HasOne(g => g.Subject)
                .WithMany()
                .HasForeignKey("SubjectID");
        }
    }
}
