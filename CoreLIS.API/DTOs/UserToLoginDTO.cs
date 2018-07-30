using System.ComponentModel.DataAnnotations;

namespace CoreLIS.API.DTOs
{
    public class UserToLoginDTO
    {
        [Required]
        public string Username { get; set; }
        
        [Required]
        public string Password { get; set; }
    }
}