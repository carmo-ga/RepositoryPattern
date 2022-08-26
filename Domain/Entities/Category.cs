namespace RepositoryPattern.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryTitle { get; set; }
        public List<Product> ProdutcsList { get; set; }
    }
}