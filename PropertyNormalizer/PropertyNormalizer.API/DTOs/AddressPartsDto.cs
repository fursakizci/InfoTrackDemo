namespace PropertyNormalizer.API.DTOs;

public record AddressPartsDto(
    string? Street, 
    string? Suburb,
    string? State,
    string? Postcode
);
