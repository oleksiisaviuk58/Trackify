namespace Trackify.Interfaces;

public interface ILocationNotifier
{
    Task NotifyLocationUpdate(Guid courierId, double latitude, double longitude);
}