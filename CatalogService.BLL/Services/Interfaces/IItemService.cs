using CatalogService.BLL.Models.Requests;
using CatalogService.BLL.Models.Responses;
using CatalogService.BLL.Pagination;
namespace CatalogService.BLL.Services.Interfaces
{
    public interface IItemService
    {
        PaginationResponse<ItemResponse> GetItems(ItemFilterPaginationRequest itemFilterPaginationRequest);
        ItemResponse GetItem(Guid id);
        ItemResponse AddItem(ItemRequest itemRequest);
        void UpdateItem(Guid id, ItemRequest itemRequest);
        void DeleteItem(Guid id);
    }
}
