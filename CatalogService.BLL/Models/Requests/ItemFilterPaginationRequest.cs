using CatalogService.BLL.Pagination;
namespace CatalogService.BLL.Models.Requests
{
    public class ItemFilterPaginationRequest : PaginationRequest
    {
        public Guid? CategoryId { get; set; }
    }
}
