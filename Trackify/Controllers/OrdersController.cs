using Microsoft.AspNetCore.Mvc;
using Trackify.API;
using Trackify.Contract;
using Trackify.Services;

namespace Trackify.Controllers;

[ApiController]
[Route("api/{controller}")]
public class OrdersController : Controller
{
    private readonly OrderService _orderService;

    public OrdersController(OrderService orderService) => _orderService = orderService;
    
    [HttpPost]
    public IActionResult Create(CreateOrderRequest request)
    {
        var order = _orderService.CreateOrder(request.CustomerId);

        return CreatedAtAction(nameof(GetById), new { id = order.Id }, order);
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(_orderService.GetAllOrders());

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var order = _orderService.GetOrderById(id);

        if (order is null)
            return NotFound();
        
        return Ok(order);
    }

    [HttpPatch("/{id}/assign-courier")]
    public IActionResult AssignCourier(Guid id, AssignCourierRequest request)
    {
        _orderService.AssignCourier(id, request.CourierId);
        
        return NoContent();
    }

    [HttpPatch("/{id/start-preparing}")]
    public IActionResult StartPreparing(Guid id)
    {
        _orderService.StartPreparing(id);
        
        return NoContent();
    }

    [HttpPatch("/{id}/ready")]
    public IActionResult ReadyForDelivery(Guid id)
    {
        _orderService.MarkAsReadyForDelivery(id);

        return NoContent();
    }

    [HttpPatch("/{id}/start-delivery")]
    public IActionResult StartDelivery(Guid id)
    {
        _orderService.StartDelivery(id);
        
        return NoContent();
    }

    [HttpPatch("/{id}/complete-delivery")]
    public IActionResult CompleteDelivery(Guid id)
    {
        _orderService.CompleteDelivery(id);

        return NoContent();
    }
}