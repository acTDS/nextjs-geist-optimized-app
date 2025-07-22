using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanguageCenterAPI.Models
{
    public class Course
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(10)]
        public string CourseCode { get; set; } = string.Empty;
        
        [Required]
        [StringLength(100)]
        public string CourseName { get; set; } = string.Empty;
        
        [StringLength(500)]
        public string? Description { get; set; }
        
        [StringLength(50)]
        public string Language { get; set; } = string.Empty;
        
        [StringLength(20)]
        public string Level { get; set; } = string.Empty; // Beginner, Intermediate, Advanced
        
        public int DurationHours { get; set; }
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal Fee { get; set; }
        
        public int MaxStudents { get; set; } = 20;
        
        public bool IsActive { get; set; } = true;
        
        [StringLength(500)]
        public string? Requirements { get; set; }
        
        [StringLength(500)]
        public string? Objectives { get; set; }
        
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        
        public DateTime? UpdatedDate { get; set; }
        
        // Navigation properties
        public virtual ICollection<Class> Classes { get; set; } = new List<Class>();
    }
}
