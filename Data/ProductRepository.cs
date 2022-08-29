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

        public async Task<IEnumerable<Product>> ListProductsAsync(int offset, string? category)
        {
            IEnumerable<Product> products = new List<Product>();

            if(!string.IsNullOrEmpty(category))
            {
                int id_category = await FindCategoryId(category);

                products = await _sqliteContext.Products
                    .Include(c => c.Category)
                    .Where(c => c.CategoryId == id_category)
                    .ToListAsync();
            }
            else
            {
                products = await _sqliteContext.Products.ToListAsync();
            }
            return products;
        }

        // Propriedade invertida - categoria
        // protected async Task<ICollection<Product>> CategoryFind(int id_category)
        // {
        //     Category filtered = await _sqliteContext.Categories.Include(pc => pc.ProdutcsList).SingleAsync(pc => pc.Id == id_category);

        //     return filtered.ProdutcsList;
        // }

        protected async Task<int> FindCategoryId(string categoryTitle)
        {
            var category = await _sqliteContext.Categories
                .Where(c => c.CategoryTitle == categoryTitle)
                .SingleOrDefaultAsync();
            return category.Id;
        }
    }
}