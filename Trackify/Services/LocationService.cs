using Tackify.Models;
using Trackify.Interfaces;

namespace Trackify.Services;

public class LocationService
{
    private readonly ILocationRepository _repository;
    private readonly ILocationNotifier _notifier;

    public LocationService(ILocationRepository repository, ILocationNotifier notifier)
    {
        _repository = repository;
        _notifier = notifier;
    }

    public async Task UpdateLocation(Guid courierId, double latitude, double longitude)
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

        await _notifier.NotifyLocationUpdate(courierId, latitude, longitude);
    }

    public CourierLocation? GetLocation(Guid courierId) => _repository.GetByCourierId(courierId);
}