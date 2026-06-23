using Tackify.Models;
using Trackify.Interfaces;

namespace Trackify.Services;

public class LocationService
{
    private readonly ILocationRepository _repository;

    public LocationService(ILocationRepository repository) => _repository = repository;

    public void UpdateLocation(Guid courierId, double latitude, double longitude)
    {
        var location = _repository.GetByCourierId(courierId);

        if (location is null)
        {
            location = new CourierLocation(courierId, latitude, longitude);
            _repository.Add(location);
            
            return;
        }

        location.Update(latitude, longitude);
        _repository.Update(location);
    }

    public CourierLocation? GetLocation(Guid courierId) => _repository.GetByCourierId(courierId);
}