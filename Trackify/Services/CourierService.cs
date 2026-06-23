using Trackify.Interfaces;
using Trackify.Models;

namespace Trackify.Services;

public class CourierService
{
    private readonly ICourierRepository _repository;

    public CourierService(ICourierRepository repository) => _repository = repository;

    public Courier Add(string name)
    {
        var courier = new Courier(name);

        _repository.Add(courier);

        return courier;
    }

    public IEnumerable<Courier> GetAll() => _repository.GetAll();

    public Courier? GetById(Guid id) => _repository.GetById(id);

    public void AssignOrder(Guid courierId, Guid orderId)
    {
        var courier = _repository.GetById(courierId);

        if (courier is null)
            throw new Exception($"Courier with id {courierId} not found");

        courier.AssignOrder(orderId);

        _repository.Update(courier);
    }

    public void CompleteOrder(Guid courierId)
    {
        var courier = _repository.GetById(courierId);

        if (courier is null)
            throw new Exception($"Courier with id {courierId} not found");

        courier.CompleteOrder();

        _repository.Update(courier);
    }
}