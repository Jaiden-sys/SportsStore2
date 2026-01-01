using Microsoft.EntityFrameworkCore;
using SportsStore2.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpLogging(o => { });
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<StoreDbContext>(opts => { opts.UseSqlServer(builder.Configuration["ConnectionStrings:SportsStoreConnection"]); 
});
builder.Services.AddScoped<IStoreRepository, EFStoreRepository>();
var app = builder.Build();
    

app.UseStaticFiles();

app.MapControllerRoute("catpage",
"{category}/Page{productPage:int}",
    new { Controller = "Home", action = "Index" });
app.MapControllerRoute("page", "Page{productPage:int}",
    new { Controller = "Home", action = "Index", productPage = 1 });
app.MapControllerRoute("category", "{category}",
    new { Controller = "Home", action = "Index", productPage = 1 });
app.MapControllerRoute("pagination",
"Products/Page{productPage}",
    new { Controller = "Home", action = "Index", productPage = 1 });

SeedData.EnsurePopulated(app);
app.UseHttpLogging();

app.Run();
