using RepositoryPattern.Domain.Entities;
using RepositoryPattern.Domain.Interfaces.Repositories;

namespace RepositoryPattern.Domain.UseCases
{
    public enum Order
    {
        ALPHABETICAL,
        PUBLICATIONDATE
    }

    public class ListProductsUseCase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ListProductsUseCase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Product>> Execute(UserRole userRole, Order orderBy, int page, string? category)
        {
            IEnumerable<Product> products = await _unitOfWork.ProductRepository.ListProductsAsync(orderBy, page, category);
            IList<Product> resultado = new List<Product>();
            if(userRole.Equals(UserRole.USER))
            {
                foreach(var p in products)
                {
                    resultado.Add(new Product {  Id = p.Id, Title = p.Title, Description = p.Description, Image = p.Image, PublicationDate = p.PublicationDate, CategoryId = p.CategoryId }); 
                }
                products = resultado.AsEnumerable();
            }
            return products;
            // IEnumerable<Product> orderedProducts = new List<Product>();
            // if(Order.ALPHABETICAL.Equals(orderBy))
            // {
            //     orderedProducts = products.OrderBy(product => product.Title);
            // }
            // if(Order.PUBLICATIONDATE.Equals(orderBy))
            // {
            //     orderedProducts = products.OrderByDescending(product => product.PublicationDate);
            // }

            // return orderedProducts;
        }
    }
}