using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Infrastructure;
using RepositoryPattern.Domain.Entities;
using RepositoryPattern.Domain.Interfaces.Repositories;

namespace RepositoryPattern.Domain.Infrastructure.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _dbContext;

        public UserRepository(DatabaseContext context)
        {
            _dbContext = context;
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