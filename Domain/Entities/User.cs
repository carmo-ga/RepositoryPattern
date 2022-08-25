namespace RepositoryPattern.Domain.Entities
{
    public enum UserRole
    {
        USER,
        ADMIN,
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
    }
}