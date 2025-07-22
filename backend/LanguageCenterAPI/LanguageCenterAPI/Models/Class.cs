using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanguageCenterAPI.Models
{
    public class Class
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(20)]
        public string ClassCode { get; set; } = string.Empty;
        
        [Required]
        [StringLength(100)]
        public string ClassName { get; set; } = string.Empty;
        
        public int CourseId { get; set; }
        
        public int TeacherId { get; set; }
        
        public int BranchId { get; set; }
        
        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }
        
        [StringLength(20)]
        public string Schedule { get; set; } = string.Empty; // Mon-Wed-Fri, Tue-Thu-Sat, etc.
        
        public TimeSpan StartTime { get; set; }
        
        public TimeSpan EndTime { get; set; }
        
        [StringLength(50)]
        public string? Room { get; set; }
        
        public int MaxStudents { get; set; } = 20;
        
        public int CurrentStudents { get; set; } = 0;
        
        [StringLength(20)]
        public string Status { get; set; } = "Planned"; // Planned, Active, Completed, Cancelled
        
        [StringLength(500)]
        public string? Notes { get; set; }
        
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        
        public DateTime? UpdatedDate { get; set; }
        
        // Navigation properties
        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; } = null!;
        
        [ForeignKey("TeacherId")]
        public virtual Teacher Teacher { get; set; } = null!;
        
        [ForeignKey("BranchId")]
        public virtual Branch Branch { get; set; } = null!;
        
        public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
        public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
    }
}
