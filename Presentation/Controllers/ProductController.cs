using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Domain.Entities;
using RepositoryPattern.Domain.UseCases;

namespace RepositoryPattern.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> ListProdutcs([FromServices]ListProductsUseCase useCase, UserRole userRole, int offset, Order? orderBy, string? category)
        {
            var products = await useCase.Execute(userRole, offset, orderBy, category);
            return Ok(products);
        }
    }
}