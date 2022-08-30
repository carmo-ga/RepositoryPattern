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
        public async Task<IActionResult> ListProdutcs(
            [FromServices]ListProductsUseCase useCase,
            UserRole userRole,
            Order orderBy,
            int page = 1,
            string? category = "")
        {
            if(page <= 0) page = 1;
            var products = await useCase.Execute(userRole, orderBy, page, category);
            return Ok(products);
        }
    }
}