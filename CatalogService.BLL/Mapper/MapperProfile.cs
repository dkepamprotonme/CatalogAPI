using AutoMapper;
using CatalogService.BLL.Models.Requests;
using CatalogService.BLL.Models.Responses;
using CatalogService.DAL.Models;
namespace CatalogService.BLL.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CategoryRequest, Category>();
            CreateMap<Category, CategoryResponse>();
            CreateMap<ItemRequest, Item>();
            CreateMap<Item, ItemResponse>();
        }
    }
}
