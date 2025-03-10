using AcoTerra.Core.Entities.Vehicles;

namespace AcoTerra.Core.Entities.Trucks;

public sealed class Truck : Vehicle
{
    public Trailer? Trailer { get; set; }
}