using System.Collections;
using RepositoryPattern.Domain.DTO;
using RepositoryPattern.Domain.Entities;
using RepositoryPattern.Domain.Repositories;

namespace RepositoryPattern.Domain.UseCases
{
    public class ListProductsUseCase
    {
        private IProductRepository _productRepository { get; }
        public ListProductsUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> Execute(UserRole userRole, int offset, string? category)
        {
            //Task<IEnumerable<Product>> products = _productRepository.ListProductsAsync(offset, category);
            var products = await _productRepository.ListProductsAsync(offset, category);
            
            if(userRole.Equals(UserRole.USER))
            {
                List<ProductsUserDTO> productsUser = new List<ProductsUserDTO>();
                foreach(var p in products)
                {
                    productsUser.Add(new ProductsUserDTO { Id = p.Id, Title = p.Title, Description = p.Description, Image = p.Image, PublicationDate = p.PublicationDate, CategoryId = p.CategoryId});
                }
                //IEnumerable<ProductsUserDTO> enProdUser = productsUser;
                return (IEnumerable<Product>)productsUser;
                //return (IEnumerable<Product>)productsUser;
            }
            return products;
        }
    }
}