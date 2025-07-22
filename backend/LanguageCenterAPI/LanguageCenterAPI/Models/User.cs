using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace LanguageCenterAPI.Models
{
    public class User : IdentityUser
    {
        [Required]
        [StringLength(100)]
        public string FullName { get; set; } = string.Empty;
        
        public int? BranchId { get; set; }
        
        [StringLength(20)]
        public string Role { get; set; } = "Staff"; // Admin, Manager, Staff
        
        public bool IsActive { get; set; } = true;
        
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        
        public DateTime? LastLoginDate { get; set; }
        
        // Navigation properties
        public virtual Branch? Branch { get; set; }
    }
}
