﻿using AcoTerra.API.Data.Entities.Producers;

namespace AcoTerra.API.Features.Producers.SearchProducers;

internal sealed record ProducerResponse(
    int Id,
    string Name,
    string IdentificationType,
    string IdentificationNumber,
    string PhoneNumber,
    string? Email
)
{
    public static explicit operator ProducerResponse(Producer producer)
    {
        return new ProducerResponse(
            Id: producer.Id,
            Name: producer.Name,
            IdentificationType: Enum.GetName(producer.IdentificationType)!,
            IdentificationNumber: producer.IdentificationNumber,
            PhoneNumber: producer.PhoneNumber,
            Email: producer.Email
        );
    }
}