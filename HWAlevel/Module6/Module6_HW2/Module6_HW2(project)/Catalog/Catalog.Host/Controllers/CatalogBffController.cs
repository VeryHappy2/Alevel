using System.Net;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.BaseRequests;
using Catalog.Host.Models.BaseResponses;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Requests;
using Catalog.Host.Models.Requests.BaseRequests;
using Catalog.Host.Models.Requests.Paginates;
using Catalog.Host.Models.Response.BaseResponses;
using Catalog.Host.Models.Response.Paginations;
using Catalog.Host.Services.Interfaces;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Controllers;

[ApiController]
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
    [ProducesResponseType(typeof(PaginatedItemsResponse<CatalogItemDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Items(PaginatedItemsRequest request)
    {
        var result = await _catalogService.GetCatalogItemsAsync(request.PageSize, request.PageIndex);
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(CatalogItem), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetById(ByIdRequest request)
    {
        var result = await _catalogService.GetById(request.Id);
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(BaseBrandResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetByBrand(BaseBrandRequest request)
    {
        var result = await _catalogService.GetByBrand(request.Brand);
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(BaseProductResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetByType(BaseTypeRequest request)
    {
        var result = await _catalogService.GetByType(request.Type);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> GetBrands()
    {
        var result = await _catalogService.GetCatalogBrands();
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(BaseTypeResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetTypes()
    {
        var result = await _catalogService.GetCatalogTypes();
        return Ok(result);
    }
}