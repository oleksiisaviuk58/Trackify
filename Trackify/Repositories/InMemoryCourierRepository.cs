using Trackify.Interfaces;
using Trackify.Models;

namespace Trackify.Repositories;

public class InMemoryCourierRepository : ICourierRepository
{
    private readonly List<Courier> _couriers = [];

    public void Add(Courier courier) => _couriers.Add(courier);

    public Courier? GetById(Guid id) => _couriers.FirstOrDefault(x => x.Id == id);

    public IEnumerable<Courier> GetAll() => _couriers;

    public void Update(Courier courier)
    {
        
    }
}