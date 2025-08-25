using ProjectCQRS.Context;
using ProjectCQRS.CQRS.Commands.ProductCommands;
using ProjectCQRS.CQRS.Handlers.CategoryHandlers;
using ProjectCQRS.CQRS.Handlers.ProductHandlers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<CreateCategoryCommandHandler>();
builder.Services.AddScoped<UpdateCategoryCommandHandler>();
builder.Services.AddScoped<RemoveCategoryCommandHandler>();
builder.Services.AddScoped<GetCategoryQueryHandler>();
builder.Services.AddScoped<GetCategoryByIdQueryHandler>();

builder.Services.AddScoped<CreateProductCommanHandler>();
builder.Services.AddScoped<UpdateProductCommanHandler>();
builder.Services.AddScoped<RemoveProductCommanHandler>();
builder.Services.AddScoped<GetProductQueryHandler>();
builder.Services.AddScoped<GetProductByIdQueryHandler>();


builder.Services.AddScoped<CQRSContext>();



var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");

app.Run();
