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

        // public IEnumerable<Product> GetAllProducts(int offsetPage, UserRole role)
        // {
        //     return _sqliteContext.Products.ToList();
        // }

        public async Task<Product> GetProductById(int Id)
        {
            return await _sqliteContext.Products.Where(p => p.Id.Equals(Id)).FirstOrDefaultAsync();
            //return await _sqliteContext.Products.FirstOrDefaultAsync(p => p.Id.Equals(Id));
        }
    }
}