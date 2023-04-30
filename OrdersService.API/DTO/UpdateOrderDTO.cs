namespace OrdersService.DTO;

public class UpdateOrderDTO
{
    public string status { get; set; }
    public List<ProductDTO> lines { get; set; } = new();
}