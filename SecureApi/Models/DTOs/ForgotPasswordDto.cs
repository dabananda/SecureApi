using System.ComponentModel.DataAnnotations;

namespace SecureApi.Models.DTOs
{
    public class ForgotPasswordDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
