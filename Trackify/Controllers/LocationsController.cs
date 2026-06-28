using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Trackify.API;
using Trackify.Hubs;
using Trackify.Services;

namespace Trackify.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocationsController : Controller
{
    private readonly LocationService _service;
    private readonly IHubContext<CourierHub> _hubContext;

    public LocationsController(LocationService service, IHubContext<CourierHub> hubContext)
    {
        _service = service;
        _hubContext = hubContext;
    }

    [HttpPatch("{courierId}")]
    public async Task<IActionResult> UpdateLocation(Guid courierId, UpdateLocationRequest request)
    {
        _service.UpdateLocation(courierId, request.Latitude, request.Longitude);

        await _hubContext.Clients.All.SendAsync("LocationUpdated", 
            courierId, request.Latitude, request.Longitude);

        return NoContent();
    }

    [HttpGet("{courierId}")]
    public IActionResult GetLocation(Guid courierId)
    {
        var location = _service.GetLocation(courierId);

        if (location is null)
            return NotFound();

        return Ok(location);
    }
}