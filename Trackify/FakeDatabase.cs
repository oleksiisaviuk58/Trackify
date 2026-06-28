using Tackify.Models;
using Trackify.Models;

namespace Trackify;

public static class FakeDatabase
{
    public static List<User> Users { get; } = [];
    public static List<Courier> Couriers { get; set; }
    public static List<Order> Orders { get; } = [];
    public static List<CourierLocation> Locations { get; } = [];

    static FakeDatabase() => Seed();
    
    public static void Seed()
    {
        User customer1 = new(
            "Oleksii",
            "oleksii@gmail.com",
            Roles.Customer);

        User customer2 = new(
            "Ivan",
            "ivan@gmail.com",
            Roles.Customer);
        
        Users.Add(customer1);
        Users.Add(customer2);
        
        Couriers.Add(new Courier("Roman"));
        Couriers.Add(new Courier("Andrii"));
        Couriers.Add(new Courier("Taras"));

        Orders.Add(new Order(customer1.Id));
        Orders.Add(new Order(customer2.Id));
    }
}