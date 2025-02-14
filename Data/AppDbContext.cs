﻿using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Address>? Addresses { get; set; }
    public DbSet<Category>? Categories { get; set; }
    public DbSet<Customer>? Customers { get; set; }
    public DbSet<Order>? Orders { get; set; }
    public DbSet<OrderItem>? OrderItems { get; set; }
    public DbSet<Product>? Products { get; set; }

    public DbSet<Basket>? Baskets { get; set; } 

    public override int SaveChanges()
    {
        foreach (var item in ChangeTracker.Entries())
        {
            if (item.Entity is Base baseEntity)
            {
                switch (item.State)
                {
                    case EntityState.Added:
                        {
                            baseEntity.Status = true;
                            baseEntity.CreateDate = DateTime.Now;
                            break;
                        }
                    default:
                        break;
                }
            }
        }
        return base.SaveChanges();
    }
}
