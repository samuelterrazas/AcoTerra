using AcoTerra.Core.Entities.Drivers;
using AcoTerra.Core.Entities.Freights;
using AcoTerra.Core.Entities.Trucks;
using AcoTerra.Core.Features.Common.DTOs;

namespace AcoTerra.Core.Features.Freights.GetFreightDetails;

public sealed record FreightDetailsResponse(
    int Id,
    string Number,
    TruckDto Truck,
    DateOnly LoadingDate,
    DateOnly UnloadingDate,
    decimal TotalShipmentQuantity,
    decimal TotalShipmentWeight,
    decimal TotalShipmentAmount,
    string? Remarks,
    List<ShipmentDetailsDto> Shipments
)
{
    public static explicit operator FreightDetailsResponse(Freight freight)
    {
        return new FreightDetailsResponse(
            Id: freight.Id,
            Number: freight.Number,
            Truck: (TruckDto)freight.Truck,
            LoadingDate: freight.LoadingDate,
            UnloadingDate: freight.UnloadingDate,
            TotalShipmentQuantity: freight.TotalShipmentQuantity,
            TotalShipmentWeight: freight.TotalShipmentWeight,
            TotalShipmentAmount: freight.TotalShipmentAmount,
            Remarks: freight.Remarks,
            Shipments: freight.Shipments
                .Select(shipment => (ShipmentDetailsDto)shipment)
                .ToList()
        );
    }
}

public sealed record TruckDto(
    int Id,
    string LicensePlate,
    string Brand,
    string Model,
    DriverDto Driver,
    TrailerDto Trailer
)
{
    public static explicit operator TruckDto(Truck truck)
    {
        if (truck.Driver is null)
        {
            throw new InvalidOperationException($"The '{nameof(truck.Driver)}' entity has not been initialized.");
        }
        
        if (truck.Trailer is null)
        {
            throw new InvalidOperationException($"The '{nameof(truck.Trailer)}' entity has not been initialized.");
        }
        
        return new TruckDto(
            Id: truck.Id,
            LicensePlate: truck.LicensePlate,
            Brand: truck.Brand,
            Model: truck.Model,
            Driver: (DriverDto)truck.Driver,
            Trailer: (TrailerDto)truck.Trailer
        );
    }
}

public sealed record DriverDto(
    int Id,
    string Name,
    string IdentificationNumber,
    string PhoneNumber
)
{
    public static explicit operator DriverDto(Driver driver)
    {
        return new DriverDto(
            Id: driver.Id,
            Name: driver.Name,
            IdentificationNumber: driver.IdentificationNumber,
            PhoneNumber: driver.PhoneNumber
        );
    }
}

public sealed record ShipmentDetailsDto(
    int Id,
    string Number,
    ReferenceDto Producer,
    ReferenceDto Product,
    decimal TotalProductQuantity,
    decimal TotalProductWeight,
    decimal TotalProductAmount,
    ReferenceDto Customer,
    string Location,
    string Status
)
{
    public static explicit operator ShipmentDetailsDto(Shipment shipment)
    {
        return new ShipmentDetailsDto(
            Id: shipment.Id,
            Number: shipment.Number,
            Producer: new ReferenceDto(
                Id: shipment.Producer.Id,
                Name: shipment.Producer.Name
            ),
            Product: new ReferenceDto(
                Id: shipment.Product.Id,
                Name: shipment.Product.Name
            ),
            TotalProductQuantity: shipment.TotalProductQuantity,
            TotalProductWeight: shipment.TotalProductWeight,
            TotalProductAmount: shipment.TotalProductAmount,
            Customer: new ReferenceDto(
                Id: shipment.Customer.Id,
                Name: shipment.Customer.Name
            ),
            Location: shipment.Location,
            Status: Enum.GetName(shipment.Status)!
        );
    }
}