using BookStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Infrastructure.Configurations
{
    public class BookConfiguration: IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Books");
            builder.Property(x=>x.Title)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(x=>x.Description)
                .HasMaxLength(500);
            builder.Property(x=>x.ISBN)
                .IsRequired()
                .HasMaxLength(13);
            builder.HasIndex(x=>x.ISBN).IsUnique();
            builder.Property(x=>x.Price)
                .IsRequired();
            builder.Property(x => x.Slug)
                .IsRequired()
                .HasMaxLength(100);
            builder.HasIndex(x => x.Slug).IsUnique();

            builder.HasOne(x => x.Category).WithMany(t => t.Books).HasForeignKey(u => u.CategoryId);
            builder.HasOne(x=>x.Author).WithMany(t=>t.Books).HasForeignKey(u=>u.AuthorId);
        }
    }
}
