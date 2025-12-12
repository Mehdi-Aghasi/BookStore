using BookStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Infrastructure.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Authors");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(x => x.Bio)
                .HasMaxLength(300);

            builder.HasMany(x => x.Books).WithOne(t => t.Author).HasForeignKey(u => u.AuthorId);      
        }
    }
}
