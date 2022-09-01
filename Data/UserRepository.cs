using System;
using RepositoryPattern.Data;
using RepositoryPattern.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace RepositoryPattern.Domain.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SQLiteContext _sqliteContext;

        public UserRepository(SQLiteContext context)
        {
            _sqliteContext = context;
        }

        // public bool Login(string userName)
        // {
        //     throw new NotImplementedException();
        // }

        public async Task<IEnumerable<User>> ListUsersAsync()
        {
            IEnumerable<User> users = new List<User>();
            users = await _sqliteContext.Users.AsNoTracking().ToListAsync();
            return users;
        }

        public async Task<User> GetUserByIdAsync(string username, string password)
        {
            User usuario = new User();
           
            usuario = await _sqliteContext.Users
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