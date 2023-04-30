using Microsoft.EntityFrameworkCore;
using OrdersService.Application.Interfaces;
using OrdersService.Domain;
using OrdersService.Domain.Entities;

namespace OrdersService.Persistence.DbContext;

public class OrdersDbContext : Microsoft.EntityFrameworkCore.DbContext, IOrdersDbContext
{
    public DbSet<Order> Orders { get; set; }

    public DbSet<Product> Products { get; set; }

    public OrdersDbContext(DbContextOptions<OrdersDbContext> options)
        : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Order>()
            .HasMany(c => c.Products)
            .WithMany(s => s.Orders)
            .UsingEntity<OrderProduct>();
    }
}