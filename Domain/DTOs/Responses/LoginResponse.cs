using RepositoryPattern.Domain.Entities;

namespace RepositoryPattern.Domain.DTOs.Responses
{
    public class LoginResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
    }
}