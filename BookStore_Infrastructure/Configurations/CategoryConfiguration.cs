using BookStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Infrastructure.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder.HasKey(c => c.Id);
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(x => x.Description)
                .HasMaxLength(500);
            builder.Property(x=>x.Slug) .IsRequired()
                .HasMaxLength(100);
            builder.HasIndex(x => x.Slug).IsUnique();

            builder.HasMany(x => x.Books).WithOne(t => t.Category).HasForeignKey(u => u.CategoryId);
                
        }
    }
}
