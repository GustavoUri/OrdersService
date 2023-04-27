namespace OrdersService.Domain;

public class Order
{
    public Guid Id { get; set; }
    public string Status { get; set; }
    public DateTime Created { get; set; }
    public List<string> orders { get; set; }
}