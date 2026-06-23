using Tackify.Models;

namespace Trackify.Interfaces;

public interface ILocationRepository
{
    void Add(CourierLocation location);

    CourierLocation? GetByCourierId(Guid courierId);

    void Update(CourierLocation location);
}