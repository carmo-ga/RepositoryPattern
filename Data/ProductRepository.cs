using RepositoryPattern.Data;
using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

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
            //List<Product> products = new List<Product>();
            //products = await _sqliteContext.Products.Include(p => p.Category).ToListAsync();

            //IList<Product> products = await _sqliteContext.Products.Include(c => c.Category).ToListAsync();

            //IList<Product> resultado = new List<Product>();
            //IList<Product> filtered = new List<Product>();

            IEnumerable<Product> resultado = new List<Product>();
            //ICollection<Product> resultado = new List<Product>();
            if(!string.IsNullOrEmpty(category))
            {
                int id_category = await FindCategoryId(category);

                resultado = await _sqliteContext.Products.Include(c => c.Category).Where(c => c.CategoryId == id_category).ToListAsync();


                //resultado = await CategoryFind(id_category);
                //Category filtered = await _sqliteContext.Categories.Include(pc => pc.ProdutcsList).SingleAsync(c => c.Id == id_category);
                //return filtered;
                // products.ForEach(p => 
                // {
                //     if(p.CategoryId == id_category) { result.Add(p) }
                // });
                // foreach(var product in products)
                // {
                //     if(product.CategoryId == id_category) result.Add(product);
                // }
            }

            // if(ordemAlfabetica == true)
            // {
            //result.OrderByDescending(o => o.Title);
            //}
                //.Where(pc => pc.CategoryId == id_category);

            return resultado;
        }

        // protected async Task<IEnumerable<Product>> ProductsFind(int id_category)
        // {
        //     IEnumerable<Product> prods = new List<Product>();
        //     prods = await _sqliteContext.Products.Include(c => c.Category).Where(c => c.CategoryId == id_category).ToListAsync();

        //     return prods;
        // }

        // Propriedade invertida - categoria
        protected async Task<ICollection<Product>> CategoryFind(int id_category)
        {
            Category filtered = await _sqliteContext.Categories.Include(pc => pc.ProdutcsList). SingleAsync(pc => pc.Id == id_category);

            return filtered.ProdutcsList;
        }

        protected async Task<int> FindCategoryId(string category)
        {

            //var result = await _sqliteContext.Categories.Where(c => c.CategoryTitle == category);
            var result = await _sqliteContext.Categories
                .Where(c => c.CategoryTitle == category)
                .FirstOrDefaultAsync();
            int id = result.Id;
            //context.MyEntity.Any(o => o.Id == idToMatch))
            return id;
        }
    }
}