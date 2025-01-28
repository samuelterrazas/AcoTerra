namespace AcoTerra.API.Common.Abstractions;

internal interface IEndpoint
{
    public static abstract void Map(IEndpointRouteBuilder app);
}