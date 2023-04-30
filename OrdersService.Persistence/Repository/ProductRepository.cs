using System.Linq.Expressions;
using OrdersService.Application.Interfaces;
using OrdersService.Domain;
using OrdersService.Domain.Entities;

namespace OrdersService.Persistence.Repository;

public class ProductRepository : IRepository<Product>
{
    private readonly IOrdersDbContext _db;

    public ProductRepository(IOrdersDbContext db) => _db = db;

    public Product? GetById(Guid id)
    {
        var result = _db.Products.Find(id);
        return result;
    }

    public IEnumerable<Product> GetAll()
    {
        var result = _db.Products.ToList();
        return result;
    }

    public IEnumerable<Product> Find(Expression<Func<Product, bool>> expression)
    {
        var result = _db.Products.Where(expression).ToList();
        return result;
    }

    public void Add(Product entity)
    {
        _db.Products.Add(entity);
        _db.SaveChanges();
    }

    public void Delete(Product entity)
    {
        _db.Products.Remove(entity);
        _db.SaveChanges();
    }

    public void Update(Product entity)
    {
        _db.Products.Update(entity);
    }
}