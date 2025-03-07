﻿using AcoTerra.Core.Entities.Freights;

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