using OrdersService.Domain.Entities;
using OrdersService.Domain.Exceptions;
using OrdersService.DTO;

namespace OrdersService.Mappings;

public static class OrderDTOMapping
{
    public static ResponceOrderDTO ConvertOrderToResponce(Order order)
    {
        var orderForResponce = new ResponceOrderDTO()
        {
            created = order.Created.ToString("yyyy-MM-dd HH:mm.s"),
            id = order.Id,
            lines = new List<ProductDTO>(),
            status = order.Status.ToString()
        };
        foreach (var line in order.OrderProducts.Select(orderProduct => new ProductDTO()
                 {
                     id = orderProduct.ProductId,
                     qty = orderProduct.ProdQuantity
                 }))
        {
            orderForResponce.lines.Add(line);
        }

        return orderForResponce;
    }

    public static Order ConvertCreateOrderToOrder(CreateOrderDTO createOrder)
    {
        var order = new Order()
        {
            Id = createOrder.id,
            Created = DateTime.UtcNow,
            Status = OrderStatus.New,
            OrderProducts = new List<OrderProduct>(),
        };
        foreach (var productDto in createOrder.lines)
        {
            order.OrderProducts.Add(new OrderProduct()
            {
                ProductId = productDto.id,
                ProdQuantity = productDto.qty
            });
        }

        return order;
    }

    public static Order ConvertUpdateOrderToOrder(UpdateOrderDTO updateOrder)
    {
        if (!Enum.TryParse(updateOrder.status, out OrderStatus status))
            throw new BadRequestException("Некорректный статус");
        var order = new Order()
        {
            Status = status,
            OrderProducts = new List<OrderProduct>(),
        };
        foreach (var productDto in updateOrder.lines)
        {
            order.OrderProducts.Add(new OrderProduct()
            {
                ProductId = productDto.id,
                ProdQuantity = productDto.qty
            });
        }

        return order;
    }
}