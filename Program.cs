using Microsoft.EntityFrameworkCore;
using SportsStore2.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpLogging(o => { });
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<StoreDbContext>(opts => { opts.UseSqlServer(builder.Configuration["ConnectionStrings:SportsStoreConnection"]); 
});
builder.Services.AddScoped<IStoreRepository, EFStoreRepository>();
builder.Services.AddRazorPages();


var app = builder.Build();

app.UseStaticFiles();

app.MapControllerRoute("pagination",
    "Products/Page{productPage}",
    new { Controller = "Home", action = "Index" });
app.MapDefaultControllerRoute();
app.MapRazorPages();
SeedData.EnsurePopulated(app);
app.UseHttpLogging();

app.Run();
