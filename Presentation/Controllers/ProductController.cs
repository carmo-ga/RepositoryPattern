using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Domain.DTO;
using RepositoryPattern.Domain.Entities;
using RepositoryPattern.Domain.Repositories;

namespace RepositoryPattern.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [Route("/{id}")]
        [HttpGet]
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var product = await _productRepository.GetProductByIdAsync(Id);
            return product != null ? Ok(product) : NotFound("Produto não encontrado");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productRepository.GetAllProductsAsync();
            return products != null ? Ok(products) : NotFound("Produto não encontrado");
        }

       
        // Task<IEnumerable<Category>> IProductRepository.GetProductByCategory()
        // {
        //     throw new NotImplementedException();
        // }

        [Route("/UserRole/role")]
        [HttpGet]
        public async Task<IActionResult> GetProdutcsUser(UserRole role)
        {
            var products = await _productRepository.GetAllProductsAsync();
            List<ProductsUserDTO> productsUser = new List<ProductsUserDTO>();

            foreach(var p in products)
            {
                productsUser.Add(new ProductsUserDTO { Id = p.Id, Title = p.Title, Description = p.Description, Image = p.Image, PublicationDate = p.PublicationDate, CategoryId = p.CategoryId });
            }
            return productsUser.Any() ? Ok(productsUser) : BadRequest("É ADMIN");
        }
    }
}
// public class WeatherForecastController : ControllerBase
// {
//     private static readonly string[] Summaries = new[]
//     {
//         "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//     };

//     private readonly ILogger<WeatherForecastController> _logger;

//     public WeatherForecastController(ILogger<WeatherForecastController> logger)
//     {
//         _logger = logger;
//     }

//     [HttpGet(Name = "GetWeatherForecast")]
//     public IEnumerable<WeatherForecast> Get()
//     {
//         return Enumerable.Range(1, 5).Select(index => new WeatherForecast
//         {
//             Date = DateTime.Now.AddDays(index),
//             TemperatureC = Random.Shared.Next(-20, 55),
//             Summary = Summaries[Random.Shared.Next(Summaries.Length)]
//         })
//         .ToArray();
//     }
//}
