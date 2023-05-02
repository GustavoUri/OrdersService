using System.Linq.Expressions;

namespace OrdersService.Application.Contracts;

public interface IRepository<T>
{
    T? GetById(Guid id);
    IEnumerable<T> GetAll();
    IEnumerable<T> Find(Expression<Func<T, bool>> expression);
    void Add(T entity);
    void Delete(T entity);
    void Update(T entity);
}