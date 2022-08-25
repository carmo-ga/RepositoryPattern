namespace RepositoryPattern.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryTitle { get; set; }
        public ICollection<Product> Produto { get; set; }
    }
}