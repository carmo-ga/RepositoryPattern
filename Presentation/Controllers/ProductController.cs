using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Domain.Entities;
using RepositoryPattern.Domain.UseCases;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace RepositoryPattern.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> ListProdutcs(
            [FromServices]ListProductsUseCase useCase,
            Order orderBy,
            int page = 1,
            string? category = "")
        {
            User currentUser = GetCurrentUser();
            if(currentUser == null)
            {
                throw new NullReferenceException("No Token");
            }

            UserRole userRole = currentUser.Role;
            if(page <= 0) page = 1;
            var products = await useCase.Execute(userRole, orderBy, page, category);
            return Ok(products);
        }

        private User GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if(identity != null)
            {
                var userClaims = identity.Claims;

                //string role = userClaims.FirstOrDefault(r => r.Type == ClaimTypes.Role).Value;
                //UserRole userRole = (UserRole) Enum.Parse(typeof(UserRole), userClaims.FirstOrDefault(r => r.Type == ClaimTypes.Role).Value);

                return new User
                {
                    UserName = userClaims.FirstOrDefault(y => y.Type == ClaimTypes.NameIdentifier)?.Value,
                    Name = userClaims.FirstOrDefault(n => n.Type == ClaimTypes.Name)?.Value,
                    Role = (UserRole)Enum.Parse(typeof(UserRole), userClaims.FirstOrDefault(r => r.Type == ClaimTypes.Role).Value)
                };
            }
            return null;
        }
    }
}