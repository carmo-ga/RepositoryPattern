namespace RepositoryPattern.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IProductRepository ProductRepository { get; }
    }
}