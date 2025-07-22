using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanguageCenterAPI.Models
{
    public class Enrollment
    {
        public int Id { get; set; }
        
        public int StudentId { get; set; }
        
        public int ClassId { get; set; }
        
        public DateTime EnrollmentDate { get; set; } = DateTime.Now;
        
        [StringLength(20)]
        public string Status { get; set; } = "Active"; // Active, Completed, Dropped, Suspended
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal FeeAmount { get; set; }
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal PaidAmount { get; set; } = 0;
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal RemainingAmount => FeeAmount - PaidAmount;
        
        public DateTime? CompletionDate { get; set; }
        
        [StringLength(500)]
        public string? Notes { get; set; }
        
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        
        public DateTime? UpdatedDate { get; set; }
        
        // Navigation properties
        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; } = null!;
        
        [ForeignKey("ClassId")]
        public virtual Class Class { get; set; } = null!;
    }
}
