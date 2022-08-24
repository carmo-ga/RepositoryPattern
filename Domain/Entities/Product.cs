namespace RepositoryPattern.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}