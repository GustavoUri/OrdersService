using Microsoft.Extensions.DependencyInjection;
using OrdersService.Application.Contracts;

namespace OrdersService.Application.DependencyInjection;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IOrdersService, Services.OrdersService>();
    }
}