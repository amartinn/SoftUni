namespace BookShop.Data
{
    using BookShop.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class BookShopContext : DbContext
    {
        public BookShopContext() { }

        public BookShopContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<AuthorBook> AuthorsBooks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Author>(entity =>
            {
                entity.HasMany(b => b.AuthorsBooks)
                .WithOne(a => a.Author)
                .OnDelete(DeleteBehavior.Restrict);
            });
            builder.Entity<Book>(entity =>
            {
                entity.HasMany(b => b.AuthorsBooks)
                .WithOne(b => b.Book)
                .OnDelete(DeleteBehavior.Restrict);
            });
            builder.Entity<AuthorBook>(entity =>
            {
                entity.HasKey(k => new { k.AuthorId, k.BookId });
            });
        }
    }
}