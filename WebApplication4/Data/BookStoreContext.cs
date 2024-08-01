namespace WebApplication4.Data
{
    using Microsoft.EntityFrameworkCore;
  
    using WebApplication4.Models.BookStoreAPI.Models;

    namespace BookStoreAPI.Data
    {
        public class BookStoreContext : DbContext
        {
            public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options) { }

            public DbSet<Book> Books { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                // Configure the precision and scale for the Price property
                modelBuilder.Entity<Book>()
                    .Property(b => b.Price)
                    .HasColumnType("decimal(18,2)");
            }
        }
    }


}
