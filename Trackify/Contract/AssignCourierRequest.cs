namespace Trackify.Contract;

public class AssignCourierRequest
{
    public Guid OrderId { get; set; }

    public Guid CourierId { get; set; }
}