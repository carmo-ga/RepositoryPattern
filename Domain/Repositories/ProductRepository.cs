using RepositoryPattern.Data;
using Microsoft.EntityFrameworkCore;

namespace RepositoryPattern.Domain.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly SQLiteContext _sqliteContext;

        public ProductRepository(SQLiteContext context)
        {
            _sqliteContext = context;
        }
        public Product GetProductById(Guid Id)
        {
            return _sqliteContext.Products.FirstOrDefault(a => a.Id.Equals(Id));
        }
    }
}