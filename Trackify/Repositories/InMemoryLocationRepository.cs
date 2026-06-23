using Tackify.Models;
using Trackify.Interfaces;

namespace Trackify.Repositories;

public class InMemoryLocationRepository : ILocationRepository
{
    private readonly List<CourierLocation> _locations = [];

    public void Add(CourierLocation location) => _locations.Add(location);

    public CourierLocation? GetByCourierId(Guid courierId)
        => _locations.FirstOrDefault(x => x.CourierId == courierId);

    public void Update(CourierLocation location)
    {
        
    }
}