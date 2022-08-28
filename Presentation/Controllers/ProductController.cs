using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Domain.DTO;
using RepositoryPattern.Domain.Entities;
using RepositoryPattern.Domain.UseCases;

namespace RepositoryPattern.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> ListProdutcs([FromServices]ListProductsUseCase useCase, UserRole userRole, int offset, string? category)
        {
            var products = await useCase.Execute(userRole, offset, category);
            return Ok(products);
        }
    }
}