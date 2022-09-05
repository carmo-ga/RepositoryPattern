using RepositoryPattern.Infrastructure;
using RepositoryPattern.Domain.Interfaces.Repositories;

namespace RepositoryPattern.Domain.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _dbContext = null;
        private IUserRepository _userRepository;

        public IUserRepository UserRepository
        {
            get { return _userRepository = _userRepository ?? new UserRepository(_dbContext); }
        }
        private IProductRepository _productRepository;
        public IProductRepository ProductRepository
        {
            get { return _productRepository = _productRepository ?? new ProductRepository(_dbContext); }
        }

        public UnitOfWork(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}