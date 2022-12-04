using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.TotalPrice).HasPrecision(16, 2);
        builder.HasOne(x => x.Address).WithMany(x => x.Orders).HasForeignKey(x => x.AddressId);
        builder.HasOne(x => x.Customer).WithMany(x => x.Orders).HasForeignKey(x =>x.CustomerId);
    }
}
