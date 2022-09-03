using RepositoryPattern.Domain.Entities;
using RepositoryPattern.Domain.Interfaces.Repositories;

namespace RepositoryPattern.Domain.UseCases
{
    public class LoginUserUseCase
    {
        public IUserRepository _userRepository { get; }
        public LoginUserUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> Execute()
        {
            IEnumerable<User> allUsers = await _userRepository.ListUsersAsync(); 
            return allUsers;
        }

        public async Task<User> Execute(string username, string password)
        {
            User usuario = await _userRepository.GetUserByIdAsync(username, password);
            return usuario;
        }
    }
}