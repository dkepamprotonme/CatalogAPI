using CatalogService.DAL.Models;
using CatalogService.DAL.Services.Interfaces;
namespace CatalogService.DAL.Services.Concretes
{
    public class ContextSerivce : IContextService
    {
        private List<Category> _context = new List<Category>();
        public ContextSerivce()
        {
            for (int c = 100; c <= 200; c += 100)
            {
                var category = new Category() { Name = $"Category {c}" };
                for (int i = 1; i <= 20; i++)
                {
                    category.Items.Add(new Item() { Name = $"Item {c + i}", Price = c + i, CategoryId = category.Id });
                }
                _context.Add(category);
            }
        }
        public List<Category> GetContext()
        {
            return _context;
        }
    }
}
