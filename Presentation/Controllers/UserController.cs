using System.Text;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using RepositoryPattern.Domain.Entities;
using RepositoryPattern.Domain.UseCases;

namespace RepositoryPattern.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private IConfiguration _configuration;
        public UserController(IConfiguration config)
        {
            _configuration = config;
        }
        
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> ListUsers([FromServices]LoginUserUseCase useCase)
        {
            var users = await useCase.Execute();
            return Ok(users);
        }

        // [HttpGet("/{usermane}/{password}")]
        [Authorize]
        [HttpGet]
        [Route("id")]
        public async Task<IActionResult> GetUserById([FromServices]LoginUserUseCase useCase, string username, string password)
        {
            User user = await useCase.Execute(username, password);
            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromServices]LoginUserUseCase useCase,
            [FromBody] UserLoginData userData)
        {
            User user = await useCase.Execute(userData.UserName, userData.Password);

            if(user != null)
            {
                var token = GenereteToken(user);
                return Ok(token);
            }
            return NotFound("User not found.");
        }

        private string GenereteToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWTSecret"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserName),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
            };

            var token = new JwtSecurityToken(claims.ToString(),
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: credentials);
            
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}