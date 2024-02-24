using Catalog.Host.Models.BaseRequests;

namespace Catalog.Host.Models.Requests.Update
{
    public class UpdateTypeRequest : BaseTypeRequest
    {
        public int Id { get; set; }
    }
}
