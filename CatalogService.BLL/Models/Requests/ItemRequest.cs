namespace CatalogService.BLL.Models.Requests
{
    public class ItemRequest
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
    }
}
