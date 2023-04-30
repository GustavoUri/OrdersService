using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrdersService.Application.Interfaces;
using OrdersService.Domain.Entities;
using OrdersService.Persistence.DbContext;
using OrdersService.Persistence.Repository;

namespace OrdersService.Persistence.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("OrdersDb");
        services.AddDbContext<OrdersDbContext>(options => options.UseNpgsql(connectionString));
        services.AddScoped<IOrdersDbContext, OrdersDbContext>();
        services.AddScoped<IRepository<Order>, OrderRepository>();
        services.AddScoped<IRepository<Product>, ProductRepository>();
        return services;
    }
    
}