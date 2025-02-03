using AcoTerra.API.Data.Entities.Employees;
using AcoTerra.API.Data.Entities.Freights;
using AcoTerra.API.Data.Entities.Trucks;
using AcoTerra.API.Features.Common.DTOs;

namespace AcoTerra.API.Features.Freights.GetFreightDetails;

internal sealed record FreightDetailsResponse(
    int Id,
    string Number,
    TruckDto Truck,
    EmployeeDto Employee,
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
            Truck: (TruckDto)freight.Vehicle,
            Employee: (EmployeeDto)freight.Employee,
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

internal sealed record TruckDto(
    int Id,
    string LicensePlate,
    string Brand,
    string Model,
    TrailerDto Trailer
)
{
    public static explicit operator TruckDto(Truck truck)
    {
        if (truck.Trailer is null)
        {
            throw new InvalidOperationException($"The '{nameof(truck.Trailer)}' entity has not been initialized.");
        }
        
        return new TruckDto(
            Id: truck.Id,
            LicensePlate: truck.LicensePlate,
            Brand: truck.Brand,
            Model: truck.Model,
            Trailer: (TrailerDto)truck.Trailer
        );
    }
}

internal sealed record EmployeeDto(
    int Id,
    string Name,
    string IdentificationNumber,
    string PhoneNumber
)
{
    public static explicit operator EmployeeDto(Employee employee)
    {
        return new EmployeeDto(
            Id: employee.Id,
            Name: employee.Name,
            IdentificationNumber: employee.IdentificationNumber,
            PhoneNumber: employee.PhoneNumber
        );
    }
}

internal sealed record ShipmentDetailsDto(
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