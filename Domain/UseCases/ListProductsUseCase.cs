using RepositoryPattern.Domain.Entities;
using RepositoryPattern.Domain.Repositories;

namespace RepositoryPattern.Domain.UseCases
{
    public enum Order
    {
        ALPHABETICAL,
        PUBLICATIONDATE
    }

    public class ListProductsUseCase
    {
        private IProductRepository _productRepository { get; }
        public ListProductsUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> Execute(UserRole userRole, int offset, Order? orderBy, string? category)
        {
            IEnumerable<Product> products = await _productRepository.ListProductsAsync(offset, category);
            IList<Product> resultado = new List<Product>();
            if(userRole.Equals(UserRole.USER))
            {
                foreach(var p in products)
                {
                    resultado.Add(new Product {  Id = p.Id, Title = p.Title, Description = p.Description, Image = p.Image, PublicationDate = p.PublicationDate, CategoryId = p.CategoryId }); 
                }
                products = resultado.AsEnumerable();
            }

            IEnumerable<Product> orderedProducts = new List<Product>();
            if(Order.ALPHABETICAL.Equals(orderBy))
            {
                orderedProducts = products.OrderBy(product => product.Title);
            }
            if(Order.PUBLICATIONDATE.Equals(orderBy))
            {
                orderedProducts = products.OrderByDescending(product => product.PublicationDate);
            }

            return orderedProducts;
        }
    }
}