namespace AcoTerra.API.Common.Exceptions;

internal sealed class MissingConfigurationException : Exception
{
    public MissingConfigurationException() : base("A required configuration setting is missing.")
    {
    }
    
    public MissingConfigurationException(string key) 
        : base($"A required configuration setting is missing. (Key '{key}')")
    {
    }
}