using Trackify.Interfaces;

namespace Trackify.Services;

public class DeliveryService
{
    private readonly IOrderRepository _orderRepository;
    private readonly ICourierRepository _courierRepository;

    public DeliveryService(IOrderRepository orderRepository, ICourierRepository courierRepository)
    {
        _orderRepository = orderRepository;
        _courierRepository = courierRepository;
    }

    public void AssingCourier(Guid orderId, Guid courierId)
    {
        var order = _orderRepository.GetById(orderId);

        if (order is null) 
            throw new Exception("Order not found");

        var courier = _courierRepository.GetById(courierId);

        if (courier is null)
            throw new Exception("Courier not found");

        order.AssignCourier(courierId);
        courier.AssignOrder(orderId);

        _orderRepository.Update(order);
        _courierRepository.Update(courier);
    }

    public void CompleteDelivery(Guid orderId)
    {
        var order = _orderRepository.GetById(orderId);

        if (order is null)
            throw new Exception("Order not found");

        if (order.CourierId is null)
            throw new Exception("Courier not assigned.");

        var courier = _courierRepository.GetById(order.CourierId.Value);

        if (courier is null)
            throw new Exception("Courier not found");
        
        order.CompleteDelivery();
        courier.CompleteOrder();
        
        _orderRepository.Update(order);
        _courierRepository.Update(courier);
    }
}