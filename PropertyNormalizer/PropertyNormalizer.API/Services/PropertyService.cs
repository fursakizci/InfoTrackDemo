using System.Text.RegularExpressions;
using PropertyNormalizer.API.DataLayer.Repository;
using PropertyNormalizer.API.DTOs;
using PropertyNormalizer.API.Models;

namespace PropertyNormalizer.API.Services;

public class PropertyService : IPropertyService
{
    private readonly IGenericRepository<InternalProperty> _propertyRepository;

    public PropertyService(IGenericRepository<InternalProperty> propertyRepository)
    {
        _propertyRepository = propertyRepository;
    }

    public async Task<InternalProperty> GetProperty(Guid id)
    {
        return await _propertyRepository.GetByIdAsync(id);
    }

    public async Task<InternalProperty> AddNormalizeProperty(ExternalPropertyDto externalPropertyDto)
    {
        var normalized = NormalizeProperty(externalPropertyDto);

        var normalizedEntity = await _propertyRepository.AddAsync(normalized);

        return normalizedEntity;
    }

    private InternalProperty NormalizeProperty(ExternalPropertyDto p)
    {
        var fullAddress = !string.IsNullOrWhiteSpace(p.FormattedAddress)
            ? p.FormattedAddress.Trim()
            : p.AddressParts is not null
                ? Regex.Replace(
                    $"{p.AddressParts.Street}, {p.AddressParts.Suburb} {p.AddressParts.State} {p.AddressParts.Postcode}",
                    @"\s+",
                    " "
                ).Trim()
                : string.Empty;

        return new InternalProperty
        {
            FullAddress = fullAddress,
            LotPlan = new LotPlan
            {
                Lot = p.LotPlan?.Lot,
                Plan = p.LotPlan?.Plan
            },
            VolumeFolio = new VolumeFolio(p.Title?.Volume, p.Title?.Folio),
            Status = string.IsNullOrEmpty(p.Title?.Volume) || string.IsNullOrEmpty(p.Title?.Folio)
                ? PropertyStatus.UnknownVolFol  
                : PropertyStatus.KnownVolFol,
            SourceTrace = new SourceTrace(p.Provider, p.RequestId, p.ReceivedAt)
        };
    }
}