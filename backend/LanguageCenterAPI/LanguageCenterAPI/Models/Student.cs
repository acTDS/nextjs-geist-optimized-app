using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanguageCenterAPI.Models
{
    public class Student
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(10)]
        public string StudentCode { get; set; } = string.Empty;
        
        [Required]
        [StringLength(100)]
        public string FullName { get; set; } = string.Empty;
        
        public DateTime DateOfBirth { get; set; }
        
        [StringLength(10)]
        public string? Gender { get; set; }
        
        [StringLength(20)]
        public string? Phone { get; set; }
        
        [StringLength(100)]
        public string? Email { get; set; }
        
        [StringLength(200)]
        public string? Address { get; set; }
        
        [StringLength(50)]
        public string? ParentName { get; set; }
        
        [StringLength(20)]
        public string? ParentPhone { get; set; }
        
        public int BranchId { get; set; }
        
        public DateTime EnrollmentDate { get; set; } = DateTime.Now;
        
        public bool IsActive { get; set; } = true;
        
        [StringLength(500)]
        public string? Notes { get; set; }
        
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        
        public DateTime? UpdatedDate { get; set; }
        
        // Navigation properties
        [ForeignKey("BranchId")]
        public virtual Branch Branch { get; set; } = null!;
        
        public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
        public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
        public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
    }
}
