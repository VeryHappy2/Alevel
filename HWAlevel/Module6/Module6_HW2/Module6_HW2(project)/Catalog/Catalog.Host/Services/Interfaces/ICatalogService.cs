using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Response.Paginations;

namespace Catalog.Host.Services.Interfaces;

public interface ICatalogService
{
    Task<PaginatedItemsResponse<CatalogItemDto>> GetCatalogItemsAsync(int pageSize, int pageIndex);
    Task<List<string>> GetCatalogBrands();
    Task<List<string>> GetCatalogTypes();
    Task<CatalogItem> GetById(int id);
    Task<CatalogBrand> GetByBrand(string brand);
    Task<CatalogType> GetByType(string type);

}