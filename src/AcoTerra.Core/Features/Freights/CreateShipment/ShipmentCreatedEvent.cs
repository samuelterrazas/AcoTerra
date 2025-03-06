using AcoTerra.Core.Common.Abstractions;
using AcoTerra.Core.Entities.Freights;
using MediatR;

namespace AcoTerra.Core.Features.Freights.CreateShipment;

internal sealed record ShipmentCreatedEvent(int ShipmentId) : INotification;