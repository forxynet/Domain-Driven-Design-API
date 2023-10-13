using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectX.Template.Domain.Entities;

namespace ProjectX.Template.Infrastructure.Configurations {
    internal class EventConfiguration : IEntityTypeConfiguration<Event> {
        public void Configure(EntityTypeBuilder<Event> builder) {
            builder.Property(f => f.Artist).IsRequired(false);
            builder.Property(f => f.Name).HasMaxLength(50).IsRequired(true);
            builder.Property(f => f.Price).HasPrecision(18, 2).IsRequired(true);
            builder.Property(f => f.Date).IsRequired(true);
            builder.Property(f => f.Description).HasMaxLength(250).IsRequired(false);
            builder.Property(f => f.ImageUrl).HasMaxLength(100).IsRequired(false);
            builder.Property(f => f.CategoryId).IsRequired(true);
            builder.Property(f => f.Category).IsRequired(true);

            builder.HasOne(s => s.Category)
              .WithMany()
              .HasForeignKey(s => s.CategoryId)
              .HasPrincipalKey(s => s.Name)
              .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
