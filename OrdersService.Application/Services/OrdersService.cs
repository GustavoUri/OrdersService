using OrdersService.Application.Interfaces;
using OrdersService.Domain.Entities;
using OrdersService.Domain.Exceptions;

namespace OrdersService.Application.Services;

public class OrdersService : IOrdersService
{
    private readonly IRepository<Order> _orderRep;
    private readonly IRepository<Product> _prodRep;

    public OrdersService(IRepository<Order> orderRep, IRepository<Product> prodRep)
    {
        _orderRep = orderRep;
        _prodRep = prodRep;
    }

    public Order AddOrder(Order order)
    {
        if (_orderRep.GetById(order.Id) == null)
        {
            foreach (var orderProduct in order.OrderProducts.Where(orderProduct =>
                         _prodRep.GetById(orderProduct.ProductId) == null))
            {
                _prodRep.Add(new Product()
                {
                    Id = orderProduct.ProductId
                });
            }

            _orderRep.Add(order);
        }
        else
            throw new BadRequestException("Заказ с таким id уже существует");

        return order;
    }

    public Order UpdateOrder(Guid id, Order order)
    {
        var foundOrder = GetOrder(id);
        if (foundOrder.Status is OrderStatus.Paid or OrderStatus.SentForDelivery or OrderStatus.Delivered
            or OrderStatus.Completed)
            throw new BadRequestException("Заказ в таком статусе нельзя изменить");
        foundOrder.Status = order.Status;
        foreach (var orderProduct in foundOrder.OrderProducts)
        {
            foreach (var product in order.OrderProducts.Where(product => orderProduct.ProductId == product.ProductId))
            {
                orderProduct.ProdQuantity = product.ProdQuantity;
            }
        }

        _orderRep.Update(foundOrder);
        return foundOrder;
    }

    public void DeleteOrder(Guid id)
    {
        var foundOrder = GetOrder(id);
        if (foundOrder.Status is OrderStatus.SentForDelivery or OrderStatus.Delivered
            or OrderStatus.Completed)
            throw new BadRequestException("Заказ в таком статусе нельзя изменить");
        _orderRep.Delete(foundOrder);
    }

    public Order GetOrder(Guid id)
    {
        var foundOrder = _orderRep.GetById(id);
        if (foundOrder == null)
            throw new BadRequestException("Заказа с таким id не существует");
        return foundOrder;
    }
}