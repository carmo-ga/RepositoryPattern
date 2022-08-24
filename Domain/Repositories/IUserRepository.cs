using RepositoryPattern.Domain.Entities;

namespace RepositoryPattern.Domain.Repositories
{
    public interface IUserRepository
    {
        bool Login(string userName);
    }
}