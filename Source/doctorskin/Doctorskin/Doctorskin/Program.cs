using Doctors.Base;
using Doctors.Base.Interface;
using Doctors.Base.Models;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(24);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddMvc();
var connectionString = string.Empty;
connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DoctorskinCoreContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<IBase, IplBase>();
builder.Services.AddMvc().AddViewComponentsAsServices();
builder.Services.AddHttpContextAccessor();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapAreaControllerRoute(
            name: "Admin",
            areaName: "Admin",
            pattern: "Admin/{controller=Home}/{action=Index}/{id?}");
app.Run();
