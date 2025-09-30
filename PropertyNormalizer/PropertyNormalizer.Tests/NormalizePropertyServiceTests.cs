using PropertyNormalizer.API.DTOs;
using PropertyNormalizer.API.Models;
using PropertyNormalizer.API.Services;

public class PropertyServiceTests
{
    [Fact]
    public async Task AddNormalizeProperty_ShouldReturnKnownVolFol_WhenVolumeAndFolioProvided()
    {
        var repo = new FakeRepository<InternalProperty>();
        var service = new PropertyService(repo);

        var external = new ExternalPropertyDto(
            "VIC-DDP",
            "REQ-12345",
            DateTimeOffset.UtcNow,
            new AddressPartsDto("10 Example St", "Carlton", "VIC", "3053"),
            null,
            new LotPlanDto("12", "PS123456"),
            new TitleDto("123", "456")
        );

        var result = await service.AddNormalizeProperty(external);

        Assert.Equal(PropertyStatus.KnownVolFol, result.Status);
        Assert.Equal("123", result.VolumeFolio.Volume);
        Assert.Equal("456", result.VolumeFolio.Folio);
    }

    [Fact]
    public async Task AddNormalizeProperty_ShouldUseFormattedAddress_WhenProvided()
    {
        var repo = new FakeRepository<InternalProperty>();
        var service = new PropertyService(repo);

        var external = new ExternalPropertyDto(
            "VIC-DDP",
            "REQ-99999",
            DateTimeOffset.UtcNow,
            new AddressPartsDto("Ignored St", "IgnoredSuburb", "VIC", "9999"), // Buradaki address ignore edilmeli
            "50 Fancy Rd, Richmond VIC 3121", 
            new LotPlanDto("88", "PS888888"),
            new TitleDto(null, null) 
        );

        var result = await service.AddNormalizeProperty(external);

        Assert.Equal("50 Fancy Rd, Richmond VIC 3121", result.FullAddress);
        Assert.Equal(PropertyStatus.UnknownVolFol, result.Status);
    }
}