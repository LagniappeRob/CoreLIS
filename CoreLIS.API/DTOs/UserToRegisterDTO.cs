using System.ComponentModel.DataAnnotations;

namespace CoreLIS.API.DTOs
{
    public class UserToRegisterDTO
    {
        [Required]
        public string Username { get; set; }
        
        [Required]
        [StringLength(12, MinimumLength = 6, ErrorMessage = "Password Must Be 6 - 12 characters")]
        public string Password { get; set; }
    }
}