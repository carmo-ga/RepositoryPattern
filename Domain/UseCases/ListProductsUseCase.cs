using RepositoryPattern.Domain.Entities;
using RepositoryPattern.Domain.Repositories;

namespace RepositoryPattern.Domain.UseCases
{
    public class ListProductsUseCase
    {
        public IProductRepository _productRepository { get; }
        public ListProductsUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // public IEnumerable<Product> ListAllProducts(int offsetPage, UserRole role)
        // {
        //     return this._productRepository.GetAllProducts(offsetPage, role);
        // }
    }
}