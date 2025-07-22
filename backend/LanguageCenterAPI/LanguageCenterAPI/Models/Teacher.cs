using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanguageCenterAPI.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(10)]
        public string TeacherCode { get; set; } = string.Empty;
        
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
        
        [StringLength(100)]
        public string? Qualification { get; set; }
        
        [StringLength(100)]
        public string? Specialization { get; set; }
        
        public DateTime HireDate { get; set; } = DateTime.Now;
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal? Salary { get; set; }
        
        public int BranchId { get; set; }
        
        public bool IsActive { get; set; } = true;
        
        [StringLength(500)]
        public string? Notes { get; set; }
        
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        
        public DateTime? UpdatedDate { get; set; }
        
        // Navigation properties
        [ForeignKey("BranchId")]
        public virtual Branch Branch { get; set; } = null!;
        
        public virtual ICollection<Class> Classes { get; set; } = new List<Class>();
    }
}
