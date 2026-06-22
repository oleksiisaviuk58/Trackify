using Tackify.Models;
using Trackify.Interfaces;

namespace Trackify.Services;

public class OrderService
{
    private readonly IOrderRepository _repository;

    public OrderService(IOrderRepository repository) => _repository = repository;

    public Order CreateOrder(Guid customerId)
    {
        var order = new Order(customerId);
        _repository.AddOrder(order);

        return order;
    }

    public Order? GetOrderById(Guid id) => _repository.GetById(id);

    public IEnumerable<Order> GetAllOrders() => _repository.GetAll();
}