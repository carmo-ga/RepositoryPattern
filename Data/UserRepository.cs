using RepositoryPattern.Data;
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

        public bool Login(string userName)
        {
            throw new NotImplementedException();
        }
    }
}