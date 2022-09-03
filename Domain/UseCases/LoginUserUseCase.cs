using RepositoryPattern.Domain.Entities;
using RepositoryPattern.Domain.Interfaces.Repositories;

namespace RepositoryPattern.Domain.UseCases
{
    public class LoginUserUseCase
    {
        private readonly IUnitOfWork _unitOfWork;
        public LoginUserUseCase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User> Execute(string username, string password)
        {
            User usuario = await _unitOfWork.UserRepository.GetUserByIdAsync(username, password);
            return usuario;
        }
    }
}