using RepositoryPattern.Domain.Entities;

namespace RepositoryPattern.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        //bool Login(string userName);
        Task<IEnumerable<User>> ListUsersAsync();
        Task<User> GetUserByIdAsync(string username, string password);
    }
}