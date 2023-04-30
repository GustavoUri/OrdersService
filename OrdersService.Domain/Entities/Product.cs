using System.Text.Json.Serialization;

namespace OrdersService.Domain.Entities;

public class Product
{
    public Guid Id { get; set; }

    [JsonIgnore] public List<Order> Orders { get; set; } = new();
    [JsonIgnore] public List<OrderProduct> OrderProducts { get; set; } = new();
}