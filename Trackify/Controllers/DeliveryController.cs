using Microsoft.AspNetCore.Mvc;
using Trackify.Contract;
using Trackify.Services;

namespace Trackify.Controllers;

[ApiController]
[Route("api/delivery")]
public class DeliveryController : Controller
{
    private readonly DeliveryService _deliveryService;

    public DeliveryController(DeliveryService deliveryService) => _deliveryService = deliveryService;

    [HttpPatch("assign-courier")]
    public IActionResult AssignCourier(AssignCourierRequest request)
    {
        _deliveryService.AssingCourier(request.OrderId, request.CourierId);

        return NoContent();
    }
}