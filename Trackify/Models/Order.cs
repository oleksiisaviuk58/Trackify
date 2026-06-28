using System.Collections.Specialized;
using Trackify.Models;

namespace Tackify.Models;

public class Order
{
    public Guid Id { get; private set; }
    public Guid CustomerId { get; private set; }
    public Guid? CourierId { get; private set; }
    public OrderStatus Status { get; private set; }
    public decimal TotalPrice { get; private set; }
    public DateTime CreatedAt { get; set; }
    public List<OrderItem> _items { get; set; } = [];
    public IReadOnlyCollection<OrderItem> Items => _items;

    public Order(Guid customerId)
    {
        Id = Guid.NewGuid();
        CustomerId = customerId;
        Status = OrderStatus.Created;
        CreatedAt = DateTime.UtcNow;
    }

    public void AddItem(MenuItem menuItem, int quantity)
    {
        var orderItem = new OrderItem(menuItem.Id, menuItem.Name, menuItem.Price, quantity);
        _items.Add(orderItem);

        RecalculateTotal();
    }

    private void RecalculateTotal()
    {
        TotalPrice = _items.Sum(x => x.TotalPrice);
    }

    public void AssignCourier(Guid courierId)
    {
        if (CourierId is not null)
            throw new InvalidOperationException("Courier already assigned.");

        CourierId = courierId;
    }

    public void StartPreparing()
    {
        if (Status != OrderStatus.Created)
            throw new InvalidOperationException("Cannot start preparing.");

        Status = OrderStatus.Preparing;
    }
    
    public void MarkAsReadyForDelivery()
    {
        if (Status != OrderStatus.Preparing)
            throw new InvalidOperationException("Cannot ready for delivery.");

        Status = OrderStatus.ReadyForDelivery;
    }

    public void StartDelivery()
    {
        if (CourierId is null)
            throw new InvalidOperationException("Courier is not assigned.");

        if (Status != OrderStatus.ReadyForDelivery)
            throw new InvalidOperationException("Mark is not ready for delivery.");

        Status = OrderStatus.Delivering;
    }

    public void CompleteDelivery()
    {
        if (Status != OrderStatus.Delivering)
            throw new InvalidOperationException("Cannot complete delivery.");

        Status = OrderStatus.Delivered;
    }

    public void Cancel()
    {
        if (Status == OrderStatus.Delivered)
            throw new InvalidOperationException("Cannot cancel delivery.");

        Status = OrderStatus.Cancelled;
    }
}