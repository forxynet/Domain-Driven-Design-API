using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectX.Template.Domain.Entities;

namespace ProjectX.Template.Infrastructure.Configurations {
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category> {
        public void Configure(EntityTypeBuilder<Category> builder) {
            builder.Property(e => e.Name).HasMaxLength(50).IsRequired(true);
            builder.HasMany(e => e.Events)
                   .WithOne(e => e.Category)
                   .HasForeignKey(e => e.EventId)
                   .IsRequired(false);
        }
    }
}
