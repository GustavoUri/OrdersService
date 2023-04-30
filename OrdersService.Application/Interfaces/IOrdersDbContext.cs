using Microsoft.EntityFrameworkCore;
using OrdersService.Domain.Entities;

namespace OrdersService.Application.Interfaces;

public interface IOrdersDbContext
{
    DbSet<Order> Orders { get; set; }
    DbSet<Product> Products { get; set; }
    int SaveChanges();
}