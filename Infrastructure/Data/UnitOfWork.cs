using RepositoryPattern.Infrastructure;
using RepositoryPattern.Domain.Entities;
using RepositoryPattern.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<User>> ListUsersAsync()
        {
            IEnumerable<User> users = new List<User>();
            users = await _dbContext.Users.AsNoTracking().ToListAsync();
            return users;
        }

        public async Task<User> GetUserByIdAsync(string username, string password)
        {
            User usuario = new User();
           
            usuario = await _dbContext.Users
                .AsNoTracking()
                .SingleOrDefaultAsync(u => u.UserName == username && u.Password == password);

            if(usuario == null)
            {   
                throw new NullReferenceException();
            }
            return usuario;
        }
    }
}