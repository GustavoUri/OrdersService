using Microsoft.Extensions.DependencyInjection;
using OrdersService.Application.Interfaces;

namespace OrdersService.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IOrdersService, Services.OrdersService>();
        return services;
    }
}