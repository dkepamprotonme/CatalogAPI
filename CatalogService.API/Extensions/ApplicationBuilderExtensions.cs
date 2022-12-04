using CatalogService.API.Middlewares;
namespace CatalogService.API.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder AddGlobalErrorHandler(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<GlobalErrorHandlingMiddleware>();
        }
    }
}
