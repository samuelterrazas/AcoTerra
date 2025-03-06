using MediatR;

namespace AcoTerra.Core.Common.Abstractions.Messaging;

public interface ICommand : IRequest, ICommandMarker;

public interface ICommand<TResponse> : IRequest<TResponse>, ICommandMarker;

public interface ICommandMarker;