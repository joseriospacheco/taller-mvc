using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TallerMVC.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TallerMVCContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("TallerMVCContext") ?? throw new InvalidOperationException("Connection string 'TallerMVCContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
