using AutoMapper;
using Catalog.Host.Configurations;
using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Response.Paginations;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Services;

public class CatalogService : BaseDataService<ApplicationDbContext>, ICatalogService
{
    private readonly ICatalogItemRepository _catalogItemRepository;
    private readonly IMapper _mapper;
    private readonly ICatalogBffRepository _catalogBffService;

    public CatalogService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        ICatalogBffRepository catalogBffService,
        ICatalogItemRepository catalogItemRepository,
        IMapper mapper)
        : base(dbContextWrapper, logger)
    {
        _catalogBffService = catalogBffService; 
        _catalogItemRepository = catalogItemRepository;
        _mapper = mapper;
    }

    public async Task<PaginatedItemsResponse<CatalogItemDto>> GetCatalogItemsAsync(int pageSize, int pageIndex)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _catalogItemRepository.GetByPageAsync(pageIndex, pageSize);
            return new PaginatedItemsResponse<CatalogItemDto>()
            {
                Count = result.TotalCount,
                Data = result.Data.Select(s => _mapper.Map<CatalogItemDto>(s)).ToList(),
                PageIndex = pageIndex,
                PageSize = pageSize
            };
        });
    }

    public async Task<List<string>> GetCatalogBrands()
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _catalogBffService.GetBrandsAsync();
            return result;
        });
    }

    public async Task<List<string>> GetCatalogTypes()
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _catalogBffService.GetTypesAsync();
            return result;
        });
    }

    public async Task<CatalogItemDto> GetById(int id)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _catalogBffService.GetByIdAsync(id);
            
            var mappedResult = _mapper.Map<CatalogItemDto>(result);
            return mappedResult;
            
        });
    }

    public async Task<CatalogBrandDto> GetByBrand(string brand)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _catalogBffService.GetByBrandAsync(brand);
            var mappedResult = _mapper.Map<CatalogBrandDto>(result);
            return mappedResult;
        });
    }
    public async Task<CatalogTypeDto> GetByType(string type)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _catalogBffService.GetByTypeAsync(type);
            var mappedResult = _mapper.Map<CatalogTypeDto>(result);
            return mappedResult;
        });
    }
}