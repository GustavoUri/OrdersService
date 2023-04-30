namespace OrdersService.DTO;

public class ResponceOrderDTO
{
    public Guid id { get; set; }
    public string status { get; set; }
    public string created { get; set; }
    public List<ProductDTO> lines { get; set; }
}