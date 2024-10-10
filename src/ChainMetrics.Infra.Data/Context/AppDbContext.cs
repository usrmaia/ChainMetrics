using Microsoft.EntityFrameworkCore;

using ChainMetrics.Domain.Entities;
using ChainMetrics.Domain.DTOs;

namespace ChainMetrics.Infra.Data.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<OrderProduct> OrderProducts { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Payment>().HasNoKey();
        builder.Entity<OrderProduct>().HasNoKey();
    }
}