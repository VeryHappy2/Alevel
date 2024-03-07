using Catalog.Host.Models.Requests;
using Catalog.Host.Models.Requests.BaseRequests;
using Catalog.Host.Models.Requests.Update;
using Catalog.Host.Models.Response;
using Catalog.Host.Services;
using Catalog.Host.Services.Interfaces;
using Infrastructure;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Catalog.Host.Controllers;

[ApiController]
[Authorize(Policy = AuthPolicy.AllowClientPolicy)]
[Scope("catalog.brand")]
[Route(ComponentDefaults.DefaultRoute)]
public class CatalogBrandController : ControllerBase
{
    private readonly ILogger<CatalogBrandController> _logger;
    private readonly ICatalogTypeService _catalogBrandService;

    public CatalogBrandController(
        ILogger<CatalogBrandController> logger,
        ICatalogTypeService catalogBrandService)
    {
        _catalogBrandService = catalogBrandService;
        _logger = logger;
    }

    [HttpPost]
    [ProducesResponseType(typeof(BaseResponse<int?>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Add(BaseBrandRequest request)
    {
        int? result = await _catalogBrandService.Add(request.Brand);
        return Ok(new BaseResponse<int?>() { Id = result });
    }

    [HttpPost]
    [ProducesResponseType(typeof(BaseResponse<int?>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Update(UpdateBrandRequest request)
    {
        int? result = await _catalogBrandService.Update(request.Id, request.Brand);
        return Ok(new BaseResponse<int?>() { Id = result });
    }

    [HttpPost]
    public async Task<IActionResult> Delete(ByIdRequest request)
    {
        string result = await _catalogBrandService.Delete(request.Id);
        return Ok(result);
    }
}