using CatalogService.API.Extensions;
using CatalogService.BLL.Mapper;
using CatalogService.BLL.Services.Concretes;
using CatalogService.BLL.Services.Interfaces;
using CatalogService.DAL.Services.Concretes;
using CatalogService.DAL.Services.Interfaces;
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddLogging();
builder.Services.AddControllers();
builder.Services.AddSingleton<IContextService, ContextSerivce>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IItemService, ItemService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MapperProfile));
var app = builder.Build();
app.AddGlobalErrorHandler();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
