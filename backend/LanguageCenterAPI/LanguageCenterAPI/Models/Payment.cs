using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanguageCenterAPI.Models
{
    public class Payment
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(20)]
        public string PaymentCode { get; set; } = string.Empty;
        
        public int StudentId { get; set; }
        
        public int BranchId { get; set; }
        
        public int? EnrollmentId { get; set; }
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal Amount { get; set; }
        
        public DateTime PaymentDate { get; set; } = DateTime.Now;
        
        [StringLength(20)]
        public string PaymentMethod { get; set; } = string.Empty; // Cash, Bank Transfer, Credit Card
        
        [StringLength(50)]
        public string? TransactionReference { get; set; }
        
        [StringLength(20)]
        public string PaymentType { get; set; } = string.Empty; // Course Fee, Registration Fee, Material Fee
        
        [StringLength(20)]
        public string Status { get; set; } = "Completed"; // Pending, Completed, Cancelled, Refunded
        
        [StringLength(500)]
        public string? Notes { get; set; }
        
        [StringLength(100)]
        public string? ReceivedBy { get; set; }
        
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        
        public DateTime? UpdatedDate { get; set; }
        
        // Navigation properties
        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; } = null!;
        
        [ForeignKey("BranchId")]
        public virtual Branch Branch { get; set; } = null!;
        
        [ForeignKey("EnrollmentId")]
        public virtual Enrollment? Enrollment { get; set; }
    }
}
