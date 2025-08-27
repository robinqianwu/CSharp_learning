using Microsoft.AspNetCore.Mvc;
using CSharp_learning.Models;
using CSharp_learning.Services;

namespace CSharp_learning.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly DatabaseService _databaseService;

        public AuthController(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var user = _databaseService.ValidateUser(request.Username, request.Password);
            if (user == null)
                return Unauthorized();

            // TODO: 在实际应用中，这里应该生成JWT Token
            return Ok(new { message = "Login successful", userId = user.Id });
        }
    }

    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
