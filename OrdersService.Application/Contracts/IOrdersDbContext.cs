using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using OrdersService.Domain.Entities;

namespace OrdersService.Application.Contracts;

public interface IOrdersDbContext
{
    DbSet<Order> Orders { get; set; }
    DbSet<Product> Products { get; set; }
    int SaveChanges();
    DatabaseFacade Database { get; }
}