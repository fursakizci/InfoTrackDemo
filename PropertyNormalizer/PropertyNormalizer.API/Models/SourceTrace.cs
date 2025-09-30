namespace PropertyNormalizer.API.Models;

public record SourceTrace(
    string? Provider,
    string? RequestId, 
    DateTimeOffset? ReceivedAt);