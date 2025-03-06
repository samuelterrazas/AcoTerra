using AcoTerra.Core.Common.Abstractions.Messaging;

namespace AcoTerra.Core.Features.Trucks.DeleteTruck;

public sealed record DeleteTruckCommand(int Id) : ICommand;