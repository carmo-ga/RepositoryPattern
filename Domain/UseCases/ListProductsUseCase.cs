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

        public async Task<Product> GetProductById(int Id)
        {
            return await _productRepository.GetProductByIdAsync(Id);
        }

        public async Task<IEnumerable<Product>> ListAllProducts()
        {
            return await _productRepository.GetAllProductsAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByCategory()
        {
            return await _productRepository.GetProductByCategoryAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsUser(UserRole role)
        {
            return await _productRepository.GetProductsUserAsync(role);
        }
    }
}