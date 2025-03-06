namespace AcoTerra.Core.Common.Exceptions;

public sealed class MissingConfigurationException : Exception
{
    public MissingConfigurationException() : base("A required configuration setting is missing.")
    {
    }
    
    public MissingConfigurationException(string key) 
        : base($"A required configuration setting is missing. (Key '{key}')")
    {
    }
}