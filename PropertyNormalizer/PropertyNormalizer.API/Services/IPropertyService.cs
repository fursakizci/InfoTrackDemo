using PropertyNormalizer.API.DTOs;
using PropertyNormalizer.API.Models;

namespace PropertyNormalizer.API.Services;

public interface IPropertyService
{
    Task<InternalProperty> GetProperty (Guid id);
    Task<InternalProperty> AddNormalizeProperty(ExternalPropertyDto external);

}