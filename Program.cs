using Microsoft.EntityFrameworkCore;
using SportsStore2.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<StoreDbContext>(opts => { opts.UseSqlServer(builder.Configuration["ConnectionStrings:SportsStoreConnection"]); 
});
builder.Services.AddScoped<IStoreRepository, EFStoreRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

SeedData.EnsurePopulated(app);

app.Run();
