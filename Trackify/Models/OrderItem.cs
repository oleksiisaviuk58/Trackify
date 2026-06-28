namespace Trackify.Models;

public class OrderItem
{
    public Guid Id { get; private set; }
    public Guid MenuItemId { get; private set; }
    public string Name { get; private set; }
    public decimal UnitPrice { get; private set; }
    public int Quantity { get; private set; }
    public decimal TotalPrice => UnitPrice * Quantity;

    public OrderItem(Guid menuItemId,  string name, decimal unitPrice, int quantity)
    {
        Id = Guid.NewGuid();
        MenuItemId = menuItemId;
        Name = name;
        UnitPrice = unitPrice;
        Quantity = quantity;
    }

}