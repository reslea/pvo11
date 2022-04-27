using FirstMvcApp.Controllers;
using FirstMvcApp.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<UserDbContext>();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Register}");

app.Run();
