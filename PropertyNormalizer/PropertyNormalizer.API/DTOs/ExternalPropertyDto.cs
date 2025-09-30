namespace PropertyNormalizer.API.DTOs;
public record ExternalPropertyDto(
    string? Provider,
    string? RequestId,
    DateTimeOffset? ReceivedAt,
    AddressPartsDto? AddressParts,
    string? FormattedAddress,
    LotPlanDto? LotPlan,
    TitleDto? Title
);


    