using Microsoft.AspNetCore.Mvc;
using OrdersService.Application.Contracts;
using OrdersService.DTO;
using OrdersService.Mappings;

namespace OrdersService.Controllers;

[Route("orders")]
public class OrdersController : Controller
{
    private readonly IOrdersService _ordService;

    public OrdersController(IOrdersService ordService) => _ordService = ordService;


    [HttpPost]
    public IActionResult AddOrder([FromBody] CreateOrderDTO createOrderDto)
    {
        if (!createOrderDto.lines.Any() || createOrderDto.lines == null)
            throw new Exception("Нельзя создать заказ без строк");

        if (createOrderDto.lines.Any(line => line.qty < 1))
            throw new Exception("Количесто по строке заказа должно быть больше 0");

        var order = OrderDTOMapping.MapCreateOrderToOrder(createOrderDto);
        var res = _ordService.AddOrder(order);

        return Ok(OrderDTOMapping.MapOrderToResponce(res));
    }

    [HttpPut($"{{id:guid}}")]
    public IActionResult EditOrder(Guid id, [FromBody] UpdateOrderDTO updateOrderDto)
    {
        if (updateOrderDto.lines.Any(line => line.qty < 1))
        {
            throw new Exception("Количество должно быть больше нуля");
        }
        
        var order = OrderDTOMapping.MapUpdateOrderToOrder(updateOrderDto);
        var res = _ordService.UpdateOrder(id, order);

        return Ok(OrderDTOMapping.MapOrderToResponce(res));
    }

    [HttpDelete($"{{id:guid}}")]
    public IActionResult DeleteOrder(Guid id)
    {
        _ordService.DeleteOrder(id);

        return Ok();
    }

    [HttpGet($"{{id:guid}}")]
    public IActionResult GetOrder(Guid id)
    {
        var order = _ordService.GetOrder(id);
        var orderForResponce = OrderDTOMapping.MapOrderToResponce(order);

        return Ok(orderForResponce);
    }
}