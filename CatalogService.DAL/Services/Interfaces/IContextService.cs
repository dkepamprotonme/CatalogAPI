using CatalogService.DAL.Models;
namespace CatalogService.DAL.Services.Interfaces
{
    public interface IContextService
    {
        List<Category> GetContext();
    }
}
