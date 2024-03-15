using Catalog.Host.Models.BaseRequests;
using Catalog.Host.Models.BaseResponses;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Enums;
using Catalog.Host.Models.Requests;
using Catalog.Host.Models.Requests.BaseRequests;
using Catalog.Host.Models.Requests.Paginates;
using Catalog.Host.Models.Response.BaseResponses;
using Catalog.Host.Models.Response.Paginations;
using Catalog.Host.Services.Interfaces;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Catalog.Host.Controllers;

[ApiController]
[Authorize(Policy = AuthPolicy.AllowEndUserPolicy)]
[Route(ComponentDefaults.DefaultRoute)]
public class CatalogBffController : ControllerBase
{
    private readonly ILogger<CatalogBffController> _logger;
    private readonly ICatalogService _catalogService;

    public CatalogBffController(
        ILogger<CatalogBffController> logger,
        ICatalogService catalogService)
    {
        _logger = logger;
        _catalogService = catalogService;
    }

    [HttpPost]
    [AllowAnonymous]
    [ProducesResponseType(typeof(PaginatedItemsResponse<CatalogItemDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Items(PaginatedItemsRequest<CatalogTypeFilter> request)
    {
        var result = await _catalogService.GetCatalogItemsAsync(request.PageSize, request.PageIndex, request.Filters);
        if(result != null) 
        { 
            foreach(var item in result.Data) 
            {
                _logger.LogInformation($"Data: {item}");
            } 
        }
        
        
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(BaseProductResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetById(ByIdRequest request)
    {
        var result = await _catalogService.GetById(request.Id);
        if(result != null)
        {
            foreach (var item in result.Name)
            {
                _logger.LogInformation($"Catalog item was got object with name: {item}");
            }
        }
        
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(BaseBrandResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetByBrand(BaseBrandRequest request)
    {
        var result = await _catalogService.GetByBrand(request.Brand);
        if(result != null)
        {
            foreach (var item in result.Brand)
            {
                _logger.LogInformation($"Brand: {item}");
            }
        }
        
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(BaseProductResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetByType(BaseTypeRequest request)
    {
        var result = await _catalogService.GetByType(request.Type);
        if(result != null)
        {
            foreach (var item in result.Type)
            {
                _logger.LogInformation($"Type: {item}");
            }
        }
        
        return Ok(result);
    }

    [HttpPost]
	[AllowAnonymous]
	public async Task<IActionResult> GetBrands()
    {
        var result = await _catalogService.GetCatalogBrands();
        if (result != null)
        {
            foreach (var item in result)
            {
                _logger.LogInformation($"Brands: {item}");
            }
        }
        return Ok(result);
    }

    [HttpPost]
	[AllowAnonymous]
	[ProducesResponseType(typeof(BaseTypeResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetTypes()
    {
        var result = await _catalogService.GetCatalogTypes();
        if (result != null)
        {
            foreach (var item in result)
            {
                _logger.LogInformation($"Type: {item}" );
            }
        }
        return Ok(result);
    }
}