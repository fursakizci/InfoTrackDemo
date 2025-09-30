using System.Text.Json.Serialization;

namespace PropertyNormalizer.API.Models;

public class InternalProperty
{
    public Guid Id { get; set; } 
    public string? FullAddress { get; set; } 
    public LotPlan? LotPlan { get; set; }
    public VolumeFolio? VolumeFolio { get; set; }
    public PropertyStatus Status { get; set; }
    public SourceTrace? SourceTrace  { get; set; }
}

[JsonConverter(typeof(JsonStringEnumConverter))] 
public enum PropertyStatus
{
    UnknownVolFol,
    KnownVolFol
}