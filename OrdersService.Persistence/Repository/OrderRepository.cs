using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using OrdersService.Application.Interfaces;
using OrdersService.Domain;
using OrdersService.Domain.Entities;

namespace OrdersService.Persistence.Repository;

public class OrderRepository : IRepository<Order>
{
    private readonly IOrdersDbContext _db;

    public OrderRepository(IOrdersDbContext db) => _db = db;

    public Order? GetById(Guid id)
    {
        var result = _db.Orders.Include(order => order.OrderProducts).FirstOrDefault(order => order.Id == id);
        return result;
    }

    public IEnumerable<Order> GetAll()
    {
        var result = _db.Orders.Include(order => order.OrderProducts).ToList();
        return result;
    }

    public IEnumerable<Order> Find(Expression<Func<Order, bool>> expression)
    {
        var result = _db.Orders.Where(expression).Include(order => order.OrderProducts).ToList();
        return result;
    }

    public void Add(Order entity)
    {
        _db.Orders.Add(entity);
        _db.SaveChanges();
    }

    public void Delete(Order entity)
    {
        _db.Orders.Remove(entity);
        _db.SaveChanges();
    }

    public void Update(Order entity)
    {
        _db.Orders.Update(entity);
        _db.SaveChanges();
    }
}