using Microsoft.AspNetCore.Mvc;
using PropertyNormalizer.API.DTOs;
using PropertyNormalizer.API.Models;
using PropertyNormalizer.API.Services;

namespace PropertyNormalizer.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PropertyController : ControllerBase
{
    private readonly IPropertyService _propertyService;
    
    public PropertyController(IPropertyService propertyService)
    {
        _propertyService = propertyService;
    }
    
    [HttpPost("normalize")]
    public async Task<ActionResult<InternalProperty>> Normalize([FromBody] ExternalPropertyDto external)
    {
        var result = await _propertyService.AddNormalizeProperty(external);
        
        return Ok(result);
    } 
    
    [HttpGet("{id}")]
    public async Task<ActionResult<InternalProperty>> GetProperty(Guid id)
    {
        var result = await _propertyService.GetProperty(id);

        if (result is null)
        {
            return NotFound();
        }

        return Ok(result);
    }
}