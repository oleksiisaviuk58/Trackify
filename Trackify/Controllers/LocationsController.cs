using Microsoft.AspNetCore.Mvc;
using Trackify.API;
using Trackify.Services;

namespace Trackify.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocationsController : Controller
{
    private readonly LocationService _service;

    public LocationsController(LocationService service) => _service = service;

    [HttpPatch("{courierId}")]
    public IActionResult UpdateLocation(Guid courierId, UpdateLocationRequest request)
    {
        _service.UpdateLocation(courierId, request.Latitude, request.Longitude);

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