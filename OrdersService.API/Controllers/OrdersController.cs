using Microsoft.AspNetCore.Mvc;
using OrdersService.Application.Interfaces;
using OrdersService.Domain.Exceptions;
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
        if (!createOrderDto.lines.Any())
            throw new BadRequestException("Нельзя создать заказ без строк");
        
        if (createOrderDto.lines.Any(line => line.qty < 1))
            throw new BadRequestException("Количесто по строке заказа должно быть больше 0");

        var order = OrderDTOMapping.ConvertCreateOrderToOrder(createOrderDto);
        var res = _ordService.AddOrder(order);
        
        return Ok(OrderDTOMapping.ConvertOrderToResponce(res));
    }

    [HttpPut($"{{id:guid}}")]
    public IActionResult EditOrder(Guid id, [FromBody] UpdateOrderDTO updateOrderDto)
    {
        var order = OrderDTOMapping.ConvertUpdateOrderToOrder(updateOrderDto);
        var res = _ordService.UpdateOrder(id, order);
        
        return Ok(OrderDTOMapping.ConvertOrderToResponce(res));
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
        var orderForResponce = OrderDTOMapping.ConvertOrderToResponce(order);
        
        return Ok(orderForResponce);
    }
}