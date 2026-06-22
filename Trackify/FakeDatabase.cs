using Tackify.Models;

namespace Trackify;

public static class FakeDatabase
{
    public static List<User> Users { get; } = [];

    public static List<Order> Orders { get; } = [];

    public static List<CourierLocation> Locations { get; } = [];
}