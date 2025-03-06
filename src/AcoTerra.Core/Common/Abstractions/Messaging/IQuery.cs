using MediatR;

namespace AcoTerra.Core.Common.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<TResponse>;