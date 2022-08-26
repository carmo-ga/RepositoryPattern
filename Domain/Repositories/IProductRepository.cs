using RepositoryPattern.Domain.Entities;

namespace RepositoryPattern.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int Id);
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<IEnumerable<Product>> GetProductByCategoryAsync();
        Task<IEnumerable<Product>> GetProductsUserAsync(UserRole role);
        // public string Title { get; set; }
        // public string Description { get; set; }
        // public string Image { get; set; }
        // public decimal Price { get; set; }
        // public string Category { get; set; }
        // public DateTime PublicationDate { get; set; }
    }
}