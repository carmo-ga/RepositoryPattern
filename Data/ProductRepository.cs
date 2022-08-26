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

        public async Task<Product> GetProductByIdAsync(int Id)
        {
            return await _sqliteContext.Products.Where(p => p.Id.Equals(Id)).FirstOrDefaultAsync();
            //return await _sqliteContext.Products.FirstOrDefaultAsync(p => p.Id.Equals(Id));
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _sqliteContext.Products.ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByCategoryAsync()
        {
            return await _sqliteContext.Products.ToListAsync();
                //.Where(p => p.CategoryId == Id).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsUserAsync(UserRole role)
        {
            if(role == UserRole.USER)
            {
                return await _sqliteContext.Products.ToListAsync();
            }
            return null;
        }
    }
}