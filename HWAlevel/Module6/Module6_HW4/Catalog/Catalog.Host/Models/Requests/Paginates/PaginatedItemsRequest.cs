namespace Catalog.Host.Models.Requests.Paginates;

public class PaginatedItemsRequest
{
    public int PageIndex { get; set; }

    public int PageSize { get; set; }
}