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
    private readonly LocationService _locationService;

    public LocationsController(LocationService locationService, IHubContext<CourierHub> hubContext)
    {
        _locationService = locationService;
    }

    [HttpPatch("{courierId}")]
    public async Task<IActionResult> UpdateLocation(Guid courierId, UpdateLocationRequest request)
    {
        await _locationService.UpdateLocation(courierId, request.Latitude, request.Longitude);

        return NoContent();
    }

    [HttpGet("{courierId}")]
    public IActionResult GetLocation(Guid courierId)
    {
        var location = _locationService.GetLocation(courierId);

        if (location is null)
            return NotFound();

        return Ok(location);
    }
}