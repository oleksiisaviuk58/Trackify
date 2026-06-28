using Microsoft.AspNetCore.SignalR;
using Trackify.Hubs;
using Trackify.Interfaces;

namespace Trackify.API;

public class SignalLocationNotifier : ILocationNotifier
{
    private readonly IHubContext<CourierHub> _hubContext;

    public SignalLocationNotifier(IHubContext<CourierHub> hubContext) 
        => _hubContext = hubContext;
    
    public async Task NotifyLocationUpdate(Guid courierId, double latitude, double longitude)
    {
        await _hubContext.Clients.All.SendAsync("LocationUpdated", courierId, latitude, longitude);
    }
}