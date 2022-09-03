using RepositoryPattern.Domain.Entities;

namespace RepositoryPattern.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(string username, string password);
    }
}