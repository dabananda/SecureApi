using System.ComponentModel.DataAnnotations;

namespace SecureApi.Models.DTOs
{
    public class AssignRoleDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
