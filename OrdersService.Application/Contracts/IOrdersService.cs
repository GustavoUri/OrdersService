using OrdersService.Domain.Entities;

namespace OrdersService.Application.Contracts;

public interface IOrdersService
{
    Order AddOrder(Order order);
    Order UpdateOrder(Guid id, Order order);
    void DeleteOrder(Guid id);
    Order GetOrder(Guid id);
}