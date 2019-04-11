using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using BookManager.Model;

namespace BookManager
{
    public class BookManagerDbContext : DbContext
    {
        public ILoggerProvider Logger { get; set; }

        public BookManagerDbContext(DbContextOptions<BookManagerDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (Logger != null)
            {
                var lf = new LoggerFactory();
                lf.AddProvider(Logger);
                optionsBuilder.UseLoggerFactory(lf);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CreateBookModel(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private static void CreateBookModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasIndex(e => e.ISBN).IsUnique();
        }
    }
}
