using RepositoryPattern.Data;
using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Domain.Entities;

namespace RepositoryPattern.Domain.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly SQLiteContext _sqliteContext;

        public ProductRepository(SQLiteContext context)
        {
            _sqliteContext = context;
        }

        public IEnumerable<Product> GetAllProducts(int offsetPage, UserRole role)
        {
            return _sqliteContext.Products.ToList();
        }

        public Product GetProductById(Guid Id)
        {
            return _sqliteContext.Products.FirstOrDefault(p => p.Id.Equals(Id));
        }
    }
}