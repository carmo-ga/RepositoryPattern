using RepositoryPattern.Domain.Entities;
using RepositoryPattern.Domain.UseCases;

namespace RepositoryPattern.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> ListProductsAsync(Order orderBy, int page, string category = "");
    }
}