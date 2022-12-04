namespace CatalogService.BLL.Pagination
{
    public static class PaginationExtension
    {
        public static PaginationResponse<T> WithPagination<T>(this ICollection<T> data, PaginationRequest paginationRequest)
        {
            var totalDataCount = data.Count();
            var maxPageSize = PaginationConfiguration.MaxPageSize;
            if (paginationRequest.PageSize < 1 || paginationRequest.PageSize > maxPageSize)
            {
                paginationRequest.PageSize = maxPageSize;
            }
            var maxPage = (int)Math.Ceiling((double)totalDataCount / paginationRequest.PageSize);
            if (maxPage == 0)
            {
                maxPage = 1;
            }
            if (paginationRequest.Page < 1)
            {
                paginationRequest.Page = 1;
            }
            if (paginationRequest.Page > maxPage)
            {
                paginationRequest.Page = maxPage;
            }
            var skip = (paginationRequest.Page - 1) * paginationRequest.PageSize;
            var pagedData = data.Skip(skip).Take(paginationRequest.PageSize).ToList();
            var allPages = Enumerable.Range(1, maxPage).ToList();
            var firstPage = allPages.First();
            var hasPreviousPage = paginationRequest.Page > 1;
            int? previousPage = null;
            if (hasPreviousPage)
            {
                previousPage = paginationRequest.Page - 1;
            }
            var hasNextPage = paginationRequest.Page < maxPage;
            int? nextPage = null;
            if (hasNextPage)
            {
                nextPage = paginationRequest.Page + 1;
            }
            var lastPage = allPages.Last();
            var pagination = new PaginationResponse<T>
            {
                Data = pagedData,
                ShownDataCount = pagedData.Count,
                TotalDataCount = totalDataCount,
                AllPages = allPages,
                FirstPage = firstPage,
                PreviousPage = previousPage,
                HasPreviousPage = hasPreviousPage,
                CurrentPage = paginationRequest.Page,
                HasNextPage = hasNextPage,
                NextPage = nextPage,
                LastPage = lastPage,
                PageSize = paginationRequest.PageSize
            };
            return pagination;
        }
    }
}
