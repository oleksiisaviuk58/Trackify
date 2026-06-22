using Tackify.Models;

namespace Trackify.Interfaces;

public interface IOrderRepository
{
    void AddOrder(Order order);

    Order? GetById(Guid id);

    IEnumerable<Order> GetAll();
}