using CatalogService.BLL.Models.Requests;
using CatalogService.BLL.Models.Responses;
namespace CatalogService.BLL.Services.Interfaces
{
    public interface ICategoryService
    {
        List<CategoryResponse> GetCategories();
        CategoryResponse GetCategory(Guid id);
        CategoryResponse AddCategory(CategoryRequest categoryRequest);
        void UpdateCategory(Guid id, CategoryRequest categoryRequest);
        void DeleteCategory(Guid id);
    }
}
