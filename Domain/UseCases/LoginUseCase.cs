using AutoMapper;
using RepositoryPattern.Domain.Entities;
using RepositoryPattern.Domain.DTOs.Responses;
using RepositoryPattern.Domain.Interfaces.Repositories;

namespace RepositoryPattern.Domain.UseCases
{

    public class LoginUseCaseInput
    {
        public string UserName;
        public string Password;
    }

    public class LoginUseCase : LoginUseCaseInput
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public LoginUseCase(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<LoginResponse> Execute(LoginUseCaseInput input)
        {
            User user = await _unitOfWork.UserRepository.GetUserByIdAsync(input.UserName, input.Password);
            return await Task.FromResult(_mapper.Map<LoginResponse>(user));
        }
    }
}