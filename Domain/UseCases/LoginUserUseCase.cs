using RepositoryPattern.Domain.Repositories;

namespace RepositoryPattern.Domain.UseCases
{
    public class LoginUserUseCase
    {
        public IUserRepository _userRepository { get; }
        public LoginUserUseCase(IUserRepository userRepository)
        {
            
        }

        public bool LoginUser(string userName)
        {
            return this._userRepository.Login(userName);
        }
    }
}