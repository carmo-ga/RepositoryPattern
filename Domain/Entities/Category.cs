namespace RepositoryPattern.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryTitle { get; set; }
        public virtual ICollection<Product> ProdutcsList { get; set; }
    }
}