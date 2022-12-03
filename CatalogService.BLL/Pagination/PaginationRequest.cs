﻿namespace CatalogService.BLL.Pagination
{
    public class PaginationRequest
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = PaginationConfiguration.MaxPageSize;
    }
}
