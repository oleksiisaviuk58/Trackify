using Microsoft.AspNetCore.Mvc;
using Trackify.API;
using Trackify.Services;

namespace Trackify.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CouriersController : Controller
{
    private readonly CourierService _service;

    public CouriersController(CourierService service) => _service = service;

    [HttpPost]
    public IActionResult Create(CreateCourierRequest request)
    {
        var courier = _service.Add(request.Name);

        return CreatedAtAction(nameof(GetById), new { id = courier.Id }, courier);
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(_service.GetAll());

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var courier = _service.GetById(id);

        if (courier is null)
            return NotFound();

        return Ok(courier);
    }
}