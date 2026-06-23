namespace Trackify.Models;

public class Courier
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public bool IsAvailable { get; private set; }
    public Guid? CurrentOrderId { get; private set; }

    public Courier(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
        IsAvailable = true;
    }

    public void AssignOrder(Guid orderId)
    {
        if (!IsAvailable)
            throw  new InvalidOperationException("Courier is busy.");
        
        CurrentOrderId = orderId;
        IsAvailable = false;
    }

    public void CompleteOrder()
    {
        CurrentOrderId = null;
        IsAvailable = true;
    }
}