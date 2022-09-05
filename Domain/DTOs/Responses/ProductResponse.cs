using RepositoryPattern.Domain.Entities;

namespace RepositoryPattern.Domain.DTOs.Responses
{
    public class ProductResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public DateTime? PublicationDate { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}