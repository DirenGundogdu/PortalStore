﻿using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.AddressLine).HasMaxLength(250);
        builder.Property(x => x.Country).HasMaxLength(30);
        builder.Property(x => x.City).HasMaxLength(30);
        builder.Property(x => x.District).HasMaxLength(30);
        builder.HasOne(x => x.Customer).WithMany(x => x.Addresses).HasForeignKey(x => x.CustomerId).OnDelete(DeleteBehavior.NoAction);
    }
}
