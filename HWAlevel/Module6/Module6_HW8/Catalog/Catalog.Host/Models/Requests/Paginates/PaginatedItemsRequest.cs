using System.ComponentModel.DataAnnotations;

namespace Catalog.Host.Models.Requests.Paginates;

public class PaginatedItemsRequest<T>
    where T : notnull
{
    public int PageIndex { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "The field must be greater than or equal to 1.")]
    public int PageSize { get; set; }

    public Dictionary<T, int>? Filters { get; set; }
}