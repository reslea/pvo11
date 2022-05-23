using FirstMvcApp.Database;
using FirstMvcApp.Helpers;
using FirstMvcApp.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(
    config => config.Filters.Add<RequreRoleFilter>());

builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<UserDbContext>();

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<IBookingSerice, BookingService>();
builder.Services.AddScoped<ClaimsWrapper>();
builder.Services.AddScoped<RequreRoleFilter>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "SUPERCOOKIE";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
        options.SlidingExpiration = true;
        options.AccessDeniedPath = "/Home/Error";

        options.LoginPath = "/Auth/Login";
    });

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseMiddleware<RequestLanguageMiddleware>();

//app.Use(async (context, next) =>
//{
//    if (!context.Request.IsHttps)
//    {
//        context.Response.StatusCode = 302;
//        context.Response.Headers.Add("location", "https://google.com");
//    }
//    else
//    {
//        await next(context);
//    }
//});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Booking}/{action=Index}");

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<UserDbContext>();
    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();
}
app.Run();
