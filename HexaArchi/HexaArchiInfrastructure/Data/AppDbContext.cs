using HexaArchi.Domain.Models;
using HexaArchi.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace HexaArchi.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }

        public DbSet<Article> Articles { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new ArticleConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
