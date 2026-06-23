using Trackify.Models;

namespace Trackify.Interfaces;

public interface ICourierRepository
{
    void Add(Courier courier);
    
    Courier? GetById(Guid id);
    
    IEnumerable<Courier> GetAll();

    void Update(Courier courier);
}