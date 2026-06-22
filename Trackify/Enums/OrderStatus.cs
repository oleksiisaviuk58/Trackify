namespace Tackify.Models;

public enum OrderStatus
{
    Created = 1,
    Preparing = 2,
    ReadyForDelivery = 3,
    Delivering = 4,
    Delivered = 5,
    Cancelled = 6
}