using System;
using RepositoryPattern.Infrastructure;
using RepositoryPattern.Domain.Entities;
using RepositoryPattern.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace RepositoryPattern.Domain.Infrastructure.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _dbContext;

        public UserRepository(DatabaseContext context)
        {
            _dbContext = context;
        }

        // public bool Login(string userName)
        // {
        //     throw new NotImplementedException();
        // }

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