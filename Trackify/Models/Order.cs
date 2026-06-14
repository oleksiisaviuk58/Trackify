namespace Tackify.Models;

public class Order
{
    public Guid Id { get; set; }

    public Guid CustomerId { get; set; }

    public Guid? CourierId { get; set; }

    public OrderStatus Status { get; set; }
}