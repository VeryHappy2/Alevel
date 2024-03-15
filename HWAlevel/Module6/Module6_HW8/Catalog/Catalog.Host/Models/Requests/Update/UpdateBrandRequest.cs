using Catalog.Host.Models.Requests.BaseRequests;
using System.ComponentModel.DataAnnotations;

namespace Catalog.Host.Models.Requests.Update
{
    public class UpdateBrandRequest : BaseBrandRequest
    {
        public int Id { get; set; }
    }
}
