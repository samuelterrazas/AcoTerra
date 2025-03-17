namespace AcoTerra.Core.Common.Exceptions;

public sealed class NotFoundException : Exception
{
    public NotFoundException() : base("El recurso solicitado no fue encontrado.")
    {
    }

    public NotFoundException(string message) : base(message)
    {
    }
}