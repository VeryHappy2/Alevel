using Catalog.Host.Models.BaseRequests;
using Catalog.Host.Models.Requests;
using Catalog.Host.Models.Requests.Update;
using Catalog.Host.Models.Response;
using Catalog.Host.Services.Interfaces;
using Infrastructure;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Catalog.Host.Controllers;

[ApiController]
[Authorize(Policy = AuthPolicy.AllowClientPolicy)]
[Scope("catalog.type")]
[Route(ComponentDefaults.DefaultRoute)]
public class CatalogTypeController : ControllerBase
{
    private readonly ILogger<CatalogTypeController> _logger;
    private readonly ICatalogTypeService _catalogTypeService;

    public CatalogTypeController(
        ILogger<CatalogTypeController> logger,
        ICatalogTypeService catalogTypeService
        )
    {
        _catalogTypeService = catalogTypeService;
        _logger = logger;
    }

    [HttpPost]
    [ProducesResponseType(typeof(BaseResponse<int?>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Add(BaseTypeRequest request)
    {
        int? result = await _catalogTypeService.Add(request.Type);
        return Ok(new BaseResponse<int?>() { Id = result });
    }

    [HttpPost]
    [ProducesResponseType(typeof(BaseResponse<int?>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Update(UpdateTypeRequest request)
    {
        int? result = await _catalogTypeService.Update(request.Id, request.Type);
        return Ok(new BaseResponse<int?>() { Id = result });
    }

    [HttpPost]
    public async Task<IActionResult> Delete(ByIdRequest request)
    {
        string result = await _catalogTypeService.Delete(request.Id);
        return Ok(result);
    }
}