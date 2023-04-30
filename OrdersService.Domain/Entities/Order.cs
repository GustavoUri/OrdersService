using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace OrdersService.Domain.Entities;

public class Order
{
    public Guid Id { get; set; }
    [Required]
    [Column(TypeName = "integer")]
    public OrderStatus Status { get; set; }
    [Required]
    public DateTime Created { get; set; }
    [JsonIgnore]
    public List<Product>? Products { get; set; } = new();
    [JsonIgnore]
    public List<OrderProduct> OrderProducts { get; set; } = new();
}