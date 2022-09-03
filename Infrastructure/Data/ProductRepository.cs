using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Infrastructure;
using RepositoryPattern.Domain.UseCases;
using RepositoryPattern.Domain.Entities;
using RepositoryPattern.Domain.Interfaces.Repositories;

namespace RepositoryPattern.Domain.Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly DatabaseContext _dbContext;

        public ProductRepository(DatabaseContext context)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<Product>> ListProductsAsync(Order orderBy, int page, string? category)
        {
            int take = 5;
            int skip = 0;
            if(page > 1)
            {
                skip = take * (page - 1);
            }

            int totalRows = await _dbContext.Products.CountAsync();
            IEnumerable<Product> products = new List<Product>();

            if(!string.IsNullOrEmpty(category))
            {
                int id_category = await FindCategoryId(category);

                products = await _dbContext.Products
                    .Include(c => c.Category)
                    .Where(c => c.CategoryId == id_category)
                    .AsNoTracking()
                    .ToListAsync();
            }
            else
            {
                products = await _dbContext.Products
                    .AsNoTracking()
                    .ToListAsync();
            }

            if(Order.ALPHABETICAL.Equals(orderBy))
            {
                products = products.OrderBy(product => product.Title);
            }
            if(Order.PUBLICATIONDATE.Equals(orderBy))
            {
                products = products.OrderByDescending(product => product.PublicationDate);
            }

            return products.Skip(skip).Take(take);;
        }

        // Propriedade invertida - categoria
        // protected async Task<ICollection<Product>> CategoryFind(int id_category)
        // {
        //     Category filtered = await _sqliteContext.Categories.Include(pc => pc.ProdutcsList).SingleAsync(pc => pc.Id == id_category);

        //     return filtered.ProdutcsList;
        // }

        protected async Task<int> FindCategoryId(string categoryTitle)
        {
            var category = await _dbContext.Categories
                .Where(c => c.CategoryTitle == categoryTitle)
                .SingleOrDefaultAsync();
            return category.Id;
        }
    }
}