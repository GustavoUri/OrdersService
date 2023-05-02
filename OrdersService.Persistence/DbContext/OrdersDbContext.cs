using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using OrdersService.Application.Contracts;
using OrdersService.Domain.Entities;

namespace OrdersService.Persistence.DbContext;

public class OrdersDbContext : Microsoft.EntityFrameworkCore.DbContext, IOrdersDbContext
{
    public DbSet<Order> Orders { get; set; }

    public DbSet<Product> Products { get; set; }

    public DatabaseFacade Database => base.Database;

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