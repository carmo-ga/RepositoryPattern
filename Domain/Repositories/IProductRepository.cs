namespace RepositoryPattern.Domain.Repositories
{
    public interface IProductRepository
    {
        Product GetProductById(Guid Id);
        // public string Title { get; set; }
        // public string Description { get; set; }
        // public string Image { get; set; }
        // public decimal Price { get; set; }
        // public string Category { get; set; }
        // public DateTime PublicationDate { get; set; }
    }
}