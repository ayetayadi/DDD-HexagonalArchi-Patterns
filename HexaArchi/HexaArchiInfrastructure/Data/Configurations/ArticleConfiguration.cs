using HexaArchi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HexaArchi.Infrastructure.Data.Configurations
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("Articles")
                .HasKey(a => a.Id);

            builder.Property(a => a.Title)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(a => a.Description)
                .HasMaxLength(2000);

            builder.Property(a => a.Difficulty)
                .HasConversion<int>();

            builder.Property(a => a.WritingStatus)
                .HasConversion<int>();

            builder.HasOne(a => a.Author)
                .WithMany(a => a.Articles)
                .HasForeignKey(a => a.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
