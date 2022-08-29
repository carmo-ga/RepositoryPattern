using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Domain.Entities;

namespace RepositoryPattern.Data
{
    public class SQLiteContext : DbContext
    {
        public SQLiteContext(DbContextOptions<SQLiteContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasKey(k => k.Id);
            modelBuilder.Entity<Product>().HasKey(k => k.Id);
            modelBuilder.Entity<Category>().HasKey(k => k.Id);
            
            //.WithMany(p => p.ProdutcsList).HasForeignKey<int>(fk => fk.CategoryId);

                // .HasOne(c => c.Category)
                // .HasForeignKey(fk => fk.CategoryId);
        }
    }
}