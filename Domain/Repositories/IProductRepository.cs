using RepositoryPattern.Domain.Entities;

namespace RepositoryPattern.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetProductById(int Id);
        //IEnumerable<Product> GetAllProducts(int offsetPage, UserRole role);
        // public string Title { get; set; }
        // public string Description { get; set; }
        // public string Image { get; set; }
        // public decimal Price { get; set; }
        // public string Category { get; set; }
        // public DateTime PublicationDate { get; set; }
    }
}