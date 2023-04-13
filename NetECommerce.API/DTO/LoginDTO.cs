using System.ComponentModel.DataAnnotations;

namespace NetECommerce.API.DTO
{
    public class LoginDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
