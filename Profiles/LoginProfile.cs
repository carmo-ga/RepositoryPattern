using AutoMapper;
using RepositoryPattern.Domain.Entities;
using RepositoryPattern.Domain.DTOs.Responses;

namespace RepositoryPattern.Profiles
{
    public class LoginProfile : Profile
    {
        public LoginProfile()
        {
            CreateMap<User, LoginResponse>();
        }
    }
}