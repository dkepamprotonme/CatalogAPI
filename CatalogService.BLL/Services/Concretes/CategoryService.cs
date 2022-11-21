using AutoMapper;
using CatalogService.BLL.Exceptions;
using CatalogService.BLL.Models.Requests;
using CatalogService.BLL.Models.Responses;
using CatalogService.BLL.Services.Interfaces;
using CatalogService.DAL.Models;
using CatalogService.DAL.Services.Interfaces;
namespace CatalogService.BLL.Services.Concretes
{
    public class CategoryService : ICategoryService
    {
        private IContextService _contextService;
        private IMapper _mapper;
        public CategoryService(IContextService contextService, IMapper mapper)
        {
            _contextService = contextService;
            _mapper = mapper;
        }
        public CategoryResponse AddCategory(CategoryRequest categoryRequest)
        {
            var category = _mapper.Map<Category>(categoryRequest);
            _contextService.GetContext().Add(category);
            var categoryResponse = _mapper.Map<CategoryResponse>(category);
            return categoryResponse;
        }
        public void DeleteCategory(Guid id)
        {
            var category = _contextService.GetContext().SingleOrDefault(x => x.Id == id);
            if (category == null)
            {
                throw new NotFoundException(ExceptionMessages.CategoryNotFound);
            }
            _contextService.GetContext().Remove(category);
        }
        public List<CategoryResponse> GetCategories()
        {
            var categoryResponseList = _contextService.GetContext().Select(x => _mapper.Map<CategoryResponse>(x)).ToList();
            return categoryResponseList;
        }
        public CategoryResponse GetCategory(Guid id)
        {
            var categoryResponse = _contextService.GetContext().Select(x => _mapper.Map<CategoryResponse>(x)).SingleOrDefault(x => x.Id == id);
            if (categoryResponse == null)
            {
                throw new NotFoundException(ExceptionMessages.CategoryNotFound);
            }
            return categoryResponse;
        }
        public void UpdateCategory(Guid id, CategoryRequest categoryRequest)
        {
            var category = _contextService.GetContext().SingleOrDefault(x => x.Id == id);
            if (category == null)
            {
                throw new NotFoundException(ExceptionMessages.CategoryNotFound);
            }
            _mapper.Map(categoryRequest, category);
        }
    }
}
