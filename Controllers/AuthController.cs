using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CSharp_learning.Models;
using CSharp_learning.Services;

namespace CSharp_learning.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly DatabaseService _databaseService;
        private readonly IConfiguration _configuration;

        //public AuthController(DatabaseService databaseService, IConfiguration configuration)
        //{
        //   _databaseService = databaseService;
        //   _configuration = configuration;
        //}

        private readonly ILogger<AuthController> _logger;

        public AuthController(DatabaseService databaseService, IConfiguration configuration, ILogger<AuthController> logger)
        {
            _databaseService = databaseService;
            _configuration = configuration;
            _logger = logger;
        }

        [HttpPost("login")]
        public ActionResult<LoginResponse> Login([FromBody] LoginRequest request)
        {

            _logger.LogInformation("Login attempt for user: {Username}", request.Username);

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid model state for login request");
                return BadRequest(ModelState);
            }

            var user = _databaseService.GetUserByCredentials(request.Username, request.Password);
            if (user == null)
                return Unauthorized(new { message = "用户名或密码错误" });

            var token = GenerateJwtToken(user);

            var response = new LoginResponse
            {
                Token = token,
                Username = user.Username,
                UserId = user.Id,
                Role = user.Role
            };

            return Ok(response);
        }

        private string GenerateJwtToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? throw new InvalidOperationException("JWT Key not found in configuration")));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Username),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
