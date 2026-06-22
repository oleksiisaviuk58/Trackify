using Tackify.Models;
using Trackify.Interfaces;

namespace Trackify.Repositories;

public class InMemoryOrderRepository : IOrderRepository
{
    private readonly List<Order> _orders = [];

    public void AddOrder(Order order) => _orders.Add(order);

    public Order? GetById(Guid id) => _orders.FirstOrDefault(x => x.Id == id);

    public IEnumerable<Order> GetAll() => _orders;
}