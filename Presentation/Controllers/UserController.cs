using System.Text;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using RepositoryPattern.Domain.UseCases;
using RepositoryPattern.Domain.DTOs.Responses;
using RepositoryPattern.Presentation.Requests;

namespace RepositoryPattern.Presentation.Controllers
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

        // [HttpGet("/{usermane}/{password}")]
        // [Authorize]
        // [HttpGet]
        // [Route("id")]
        // public async Task<IActionResult> GetUserById([FromServices]LoginUseCase useCase, string username, string password)
        // {
        //     User user = await useCase.Execute(username, password);
        //     return Ok(user);
        // }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Index(
            [FromServices]LoginUseCase useCase,
            [FromBody] LoginRequest userData)
        {
            LoginResponse user = await useCase.Execute(new LoginUseCaseInput {
                UserName = userData.UserName,
                Password = userData.Password
            });

            if(user != null)
            {
                var token = GenereteToken(user);
                return Ok(token);
            }
            return NotFound("User not found.");
        }

        private string GenereteToken(LoginResponse user)
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