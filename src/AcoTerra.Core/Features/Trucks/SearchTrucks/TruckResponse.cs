﻿using AcoTerra.Core.Entities.Trucks;

namespace AcoTerra.Core.Features.Trucks.SearchTrucks;

public sealed record TruckResponse(
    int Id,
    string LicensePlate,
    string Brand,
    string Model,
    int ManufacturingYear,
    string ChassisNumber,
    string EngineNumber
)
{
    public static explicit operator TruckResponse(Truck truck)
    {
        return new TruckResponse(
            Id: truck.Id,
            LicensePlate: truck.LicensePlate,
            Brand: truck.Brand,
            Model: truck.Model,
            ManufacturingYear: truck.ManufacturingYear,
            ChassisNumber: truck.ChassisNumber,
            EngineNumber: truck.EngineNumber
        );
    }
}