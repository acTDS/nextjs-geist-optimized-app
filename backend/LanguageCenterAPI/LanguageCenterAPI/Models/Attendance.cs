using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanguageCenterAPI.Models
{
    public class Attendance
    {
        public int Id { get; set; }
        
        public int StudentId { get; set; }
        
        public int ClassId { get; set; }
        
        public DateTime AttendanceDate { get; set; }
        
        [StringLength(20)]
        public string Status { get; set; } = "Present"; // Present, Absent, Late, Excused
        
        public TimeSpan? CheckInTime { get; set; }
        
        public TimeSpan? CheckOutTime { get; set; }
        
        [StringLength(500)]
        public string? Notes { get; set; }
        
        [StringLength(100)]
        public string? RecordedBy { get; set; }
        
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        
        public DateTime? UpdatedDate { get; set; }
        
        // Navigation properties
        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; } = null!;
        
        [ForeignKey("ClassId")]
        public virtual Class Class { get; set; } = null!;
    }
}
