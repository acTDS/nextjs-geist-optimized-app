using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LanguageCenterAPI.Models;

namespace LanguageCenterAPI.Data
{
    public class LanguageCenterDbContext : IdentityDbContext<User>
    {
        public LanguageCenterDbContext(DbContextOptions<LanguageCenterDbContext> options) : base(options)
        {
        }

        public DbSet<Branch> Branches { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Attendance> Attendances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Branch)
                .WithMany(b => b.Students)
                .HasForeignKey(s => s.BranchId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Teacher>()
                .HasOne(t => t.Branch)
                .WithMany(b => b.Teachers)
                .HasForeignKey(t => t.BranchId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Class>()
                .HasOne(c => c.Course)
                .WithMany(co => co.Classes)
                .HasForeignKey(c => c.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Class>()
                .HasOne(c => c.Teacher)
                .WithMany(t => t.Classes)
                .HasForeignKey(c => c.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Class>()
                .HasOne(c => c.Branch)
                .WithMany(b => b.Classes)
                .HasForeignKey(c => c.BranchId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Class)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.ClassId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Student)
                .WithMany(s => s.Payments)
                .HasForeignKey(p => p.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Branch)
                .WithMany(b => b.Payments)
                .HasForeignKey(p => p.BranchId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Enrollment)
                .WithMany()
                .HasForeignKey(p => p.EnrollmentId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.Student)
                .WithMany(s => s.Attendances)
                .HasForeignKey(a => a.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.Class)
                .WithMany(c => c.Attendances)
                .HasForeignKey(a => a.ClassId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Branch)
                .WithMany()
                .HasForeignKey(u => u.BranchId)
                .OnDelete(DeleteBehavior.SetNull);

            // Configure indexes for better performance
            modelBuilder.Entity<Student>()
                .HasIndex(s => s.StudentCode)
                .IsUnique();

            modelBuilder.Entity<Teacher>()
                .HasIndex(t => t.TeacherCode)
                .IsUnique();

            modelBuilder.Entity<Course>()
                .HasIndex(c => c.CourseCode)
                .IsUnique();

            modelBuilder.Entity<Class>()
                .HasIndex(c => c.ClassCode)
                .IsUnique();

            modelBuilder.Entity<Payment>()
                .HasIndex(p => p.PaymentCode)
                .IsUnique();

            // Configure computed columns
            modelBuilder.Entity<Enrollment>()
                .Property(e => e.RemainingAmount)
                .HasComputedColumnSql("[FeeAmount] - [PaidAmount]");

            // Seed initial data
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // Seed Branches
            modelBuilder.Entity<Branch>().HasData(
                new Branch
                {
                    Id = 1,
                    Name = "Chi nhánh Trung tâm",
                    Address = "123 Đường ABC, Quận 1, TP.HCM",
                    Phone = "028-1234-5678",
                    Email = "central@languagecenter.com",
                    Manager = "Nguyễn Văn A",
                    IsActive = true,
                    CreatedDate = DateTime.Now
                },
                new Branch
                {
                    Id = 2,
                    Name = "Chi nhánh Quận 3",
                    Address = "456 Đường XYZ, Quận 3, TP.HCM",
                    Phone = "028-9876-5432",
                    Email = "q3@languagecenter.com",
                    Manager = "Trần Thị B",
                    IsActive = true,
                    CreatedDate = DateTime.Now
                }
            );

            // Seed Courses
            modelBuilder.Entity<Course>().HasData(
                new Course
                {
                    Id = 1,
                    CourseCode = "ENG001",
                    CourseName = "English Basic",
                    Description = "Khóa học tiếng Anh cơ bản",
                    Language = "English",
                    Level = "Beginner",
                    DurationHours = 60,
                    Fee = 2000000,
                    MaxStudents = 15,
                    IsActive = true,
                    CreatedDate = DateTime.Now
                },
                new Course
                {
                    Id = 2,
                    CourseCode = "ENG002",
                    CourseName = "English Intermediate",
                    Description = "Khóa học tiếng Anh trung cấp",
                    Language = "English",
                    Level = "Intermediate",
                    DurationHours = 80,
                    Fee = 2500000,
                    MaxStudents = 12,
                    IsActive = true,
                    CreatedDate = DateTime.Now
                }
            );
        }
    }
}
