namespace CatalogService.BLL.Pagination
{
    public class PaginationResponse<T>
    {
        public List<T> Data { get; set; }
        public int ShownDataCount { get; set; }
        public int TotalDataCount { get; set; }
        public List<int> AllPages { get; set; }
        public int FirstPage { get; set; }
        public int? PreviousPage { get; set; }
        public bool HasPreviousPage { get; set; }
        public int CurrentPage { get; set; }
        public bool HasNextPage { get; set; }
        public int? NextPage { get; set; }
        public int LastPage { get; set; }
        public int PageSize { get; set; }
    }
}
