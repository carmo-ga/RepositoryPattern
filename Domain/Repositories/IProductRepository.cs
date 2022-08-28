using RepositoryPattern.Domain.Entities;

namespace RepositoryPattern.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> ListProductsAsync(int offset, string category = "");
    }
}