using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectX.Template.Domain.Entities;

namespace ProjectX.Template.Infrastructure.Configurations {
    public class OrderConfiguration : IEntityTypeConfiguration<Order> {
        public void Configure(EntityTypeBuilder<Order> builder) {
            builder.Property(e => e.UserId).IsRequired(true);
            builder.Property(e => e.OrderPlaced).IsRequired(true);
            builder.Property(e => e.OrderPaid).IsRequired(true);
            builder.Property(e => e.OrderTotal).HasPrecision(18, 2).IsRequired(true);
            builder.Property(e => e.OrderPlaced).IsRequired(true);
            builder.Property(e => e.CreatedDate).IsRequired(true);
            builder.Property(e => e.CreatedBy).IsRequired(true);
        }
    }
}