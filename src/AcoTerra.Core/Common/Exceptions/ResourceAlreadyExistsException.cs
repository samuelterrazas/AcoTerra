namespace AcoTerra.Core.Common.Exceptions;

public sealed class ResourceAlreadyExistsException : Exception
{
    public ResourceAlreadyExistsException() : base("El recurso que intentas crear ya existe.")
    {
    }

    public ResourceAlreadyExistsException(string message) : base(message)
    {
    }
}