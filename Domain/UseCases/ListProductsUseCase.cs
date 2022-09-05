using RepositoryPattern.Domain.Entities;
using RepositoryPattern.Domain.DTOs.Responses;
using RepositoryPattern.Domain.Interfaces.Repositories;
using AutoMapper;

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
        private readonly IMapper _mapper;
        public ListProductsUseCase(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductResponse>> Execute(UserRole userRole, Order orderBy, int page, string? category)
        {
            IEnumerable<Product> products = await _unitOfWork.ProductRepository.ListProductsAsync(orderBy, page, category);

            IList<ProductResponse> resultado = new List<ProductResponse>();

            if(userRole.Equals(UserRole.USER))
            {
                var conf = new MapperConfiguration(c => c.CreateMap<Product, ProductResponse>().ForSourceMember(p => p.Price, n => n.DoNotValidate()));
                var productUserDTO = await Task.FromResult(_mapper.Map<IEnumerable<ProductResponse>>(products));
                return productUserDTO;
                // foreach(var p in products)
                // {
                //     resultado.Add(new Product {  Id = p.Id, Title = p.Title, Description = p.Description, Image = p.Image, PublicationDate = p.PublicationDate, CategoryId = p.CategoryId }); 
                // }
                // products = resultado.AsEnumerable();
            }
            var productAdminDTO = await Task.FromResult(_mapper.Map<IEnumerable<ProductResponse>>(products));
            return productAdminDTO;
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