namespace Tackify.Models;

public class CourierLocation
{
    public Guid Id { get; set; }
    public Guid CourierId { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public DateTime UpdatedAt { get; set; }

    public CourierLocation(Guid courierId, double latitude, double longitude)
    {
        Id = Guid.NewGuid();
        CourierId = courierId;
        Latitude = latitude;
        Longitude = longitude;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Update(double latitude, double longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
        UpdatedAt = DateTime.UtcNow;
    }
}