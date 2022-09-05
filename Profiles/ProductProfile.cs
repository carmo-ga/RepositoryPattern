using AutoMapper;
using RepositoryPattern.Domain.Entities;
using RepositoryPattern.Domain.DTOs.Responses;

namespace RepositoryPattern.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductResponse>().ReverseMap();
        }
    }
}