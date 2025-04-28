using System.ComponentModel.DataAnnotations; // For [Key], [Required], etc.
using System.ComponentModel.DataAnnotations.Schema; // For [Column]
namespace Project.Models
{
    public class AppUser
    {
        [Key]
        [EmailAddress]
        [MaxLength(255)]
        public string? Email { get; set; }
        
        public string? Name { get; set; }
        
        public string? Role { get; set; }
        public string? Password { get; set; } // Note: In a real application, never store passwords in plain text
    }
}