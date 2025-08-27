using System.ComponentModel.DataAnnotations;

namespace CSharp_learning.Models
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "用户名是必填项")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "密码是必填项")]
        public string Password { get; set; } = string.Empty;
    }

    public class LoginResponse
    {
        public string Token { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public int UserId { get; set; }
        public string Role { get; set; } = string.Empty;
    }
}
