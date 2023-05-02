using Microsoft.EntityFrameworkCore;
using OrdersService.Application.Contracts;

namespace OrdersService.Extencions;

public static class DbMigrationExtencion
{
    public static void AddMigration(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var context = scope.ServiceProvider.GetService<IOrdersDbContext>();
        
        if (context == null) throw new Exception("Отсутствует контекст бд");
        
        context.Database.Migrate();
    }
}