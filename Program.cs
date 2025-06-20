using Microsoft.EntityFrameworkCore;
using WebApplication5.Data;
using WebApplication5.Models;


var builder = WebApplication.CreateBuilder(args);

// Register LoginDbContext with "LoginConnection"
builder.Services.AddDbContext<LoginDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LoginConnection")));

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("NotesConnection")));

// Add Razor Pages (for login pages)
builder.Services.AddRazorPages();

// Add MVC Controllers with Views (for Notes CRUD)
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Middleware pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Map controller routes (for MVC)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Map Razor Pages (for login and other razor pages)
app.MapRazorPages();

app.Run();
