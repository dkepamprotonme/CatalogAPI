using AutoMapper;
using CatalogService.BLL.Exceptions;
using CatalogService.BLL.Models.Requests;
using CatalogService.BLL.Models.Responses;
using CatalogService.BLL.Pagination;
using CatalogService.BLL.Services.Interfaces;
using CatalogService.DAL.Models;
using CatalogService.DAL.Services.Interfaces;
namespace CatalogService.BLL.Services.Concretes
{
    public class ItemService : IItemService
    {
        private IContextService _contextService;
        private IMapper _mapper;
        public ItemService(IContextService contextService, IMapper mapper)
        {
            _contextService = contextService;
            _mapper = mapper;
        }
        public ItemResponse AddItem(ItemRequest itemRequest)
        {
            var category = _contextService.GetContext().SingleOrDefault(x => x.Id == itemRequest.CategoryId);
            if (category == null)
            {
                throw new NotFoundException(ExceptionMessages.CategoryNotFound);
            }
            var item = _mapper.Map<Item>(itemRequest);
            category.Items.Add(item);
            var itemResponse = _mapper.Map<ItemResponse>(item);
            return itemResponse;
        }
        public void DeleteItem(Guid id)
        {
            var item = _contextService.GetContext()
               .SelectMany(x => x.Items)
               .SingleOrDefault(x => x.Id == id);
            if (item == null)
            {
                throw new NotFoundException(ExceptionMessages.ItemNotFound);
            }
            var category = _contextService.GetContext().Single(x => x.Id == item.CategoryId);
            category.Items.Remove(item);
        }
        public ItemResponse GetItem(Guid id)
        {
            var itemResponse = _contextService.GetContext()
                .SelectMany(x => x.Items)
                .Select(x => _mapper.Map<ItemResponse>(x))
                .SingleOrDefault(x => x.Id == id);
            if (itemResponse == null)
            {
                throw new NotFoundException(ExceptionMessages.ItemNotFound);
            }
            return itemResponse;
        }
        public PaginationResponse<ItemResponse> GetItems(ItemFilterPaginationRequest itemFilterPaginationRequest)
        {
            var categories = _contextService.GetContext().AsEnumerable();
            if (itemFilterPaginationRequest.CategoryId != null)
            {
                categories = categories.Where(x => x.Id == itemFilterPaginationRequest.CategoryId);
            }
            var pagination = categories.SelectMany(x => x.Items)
                .Select(x => _mapper.Map<ItemResponse>(x))
                .ToList()
                .WithPagination(itemFilterPaginationRequest);
            return pagination;
        }
        public void UpdateItem(Guid id, ItemRequest itemRequest)
        {
            var item = _contextService.GetContext()
                 .SelectMany(x => x.Items)
                 .SingleOrDefault(x => x.Id == id);
            if (item == null)
            {
                throw new NotFoundException(ExceptionMessages.ItemNotFound);
            }
            if (item.CategoryId != itemRequest.CategoryId)
            {
                var newCategory = _contextService.GetContext().SingleOrDefault(x => x.Id == itemRequest.CategoryId);
                if (newCategory == null)
                {
                    throw new NotFoundException(ExceptionMessages.CategoryNotFound);
                }
                var oldCategory = _contextService.GetContext().Single(x => x.Id == item.CategoryId);
                oldCategory.Items.Remove(item);
                newCategory.Items.Add(item);
            }
            _mapper.Map(itemRequest, item);
        }
    }
}
