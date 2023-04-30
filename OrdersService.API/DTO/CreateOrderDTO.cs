namespace OrdersService.DTO;

public class CreateOrderDTO
{
    public Guid id { get; set; }
    public List<ProductDTO> lines { get; set; }

}