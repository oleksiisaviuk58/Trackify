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

    public void AssignCourier(Guid orderId, Guid courierId)
    {
        var order = _repository.GetById(orderId);
    
        if (order is null)
            throw new Exception($"Order with id {orderId} not found");
    
        order.AssignCourier(courierId);
    
        _repository.Update(order);
    }

    public void StartPreparing(Guid orderId)
    {
        var order = _repository.GetById(orderId);

        if (order is null)
            throw new Exception($"Order with id {orderId} not found");

        order.StartPreparing();

        _repository.Update(order);
    }

    public void MarkAsReadyForDelivery(Guid orderId)
    {
        var order = _repository.GetById(orderId);

        if (order is null)
            throw new Exception($"Order with id {orderId} not found");

        order.MarkAsReadyForDelivery();

        _repository.Update(order);
    }

    public void StartDelivery(Guid orderId)
    {
        var order = _repository.GetById(orderId);

        if (order is null)
            throw new Exception($"Order with id {orderId} not found");
        
        order.StartDelivery();
        
        _repository.Update(order);
    }
    
    public void CompleteDelivery(Guid orderId)
    {
        var order = _repository.GetById(orderId);

        if (order is null)
            throw new Exception($"Order with id {orderId} not found");
        
        order.CompleteDelivery();

        _repository.Update(order);
    }
}