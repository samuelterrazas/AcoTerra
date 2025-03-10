using AcoTerra.Core.Common.DTOs;
using AcoTerra.Core.Entities.Freights;

namespace AcoTerra.Core.Features.Freights.GetFreightDetails;

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