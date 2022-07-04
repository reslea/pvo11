using Booking.Data;
using Booking.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("local react", policyOptions => { policyOptions.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader(); });
});

builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddDbContext<BookingDbContext>(options => 
{
    var connectionString = config.GetConnectionString("BookingDb");
    options.UseSqlServer(connectionString);
});

builder.Services.AddSingleton<RsaSecurityKey>(provider =>
{
    RSA rsa = RSA.Create();
    var publicKeyBytes = Convert.FromBase64String(config["Jwt:Public"]);
    rsa.ImportRSAPublicKey(publicKeyBytes, out var _);

    return new RsaSecurityKey(rsa);
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    var rsaPublicKey = builder.Services.BuildServiceProvider()
    .GetRequiredService<RsaSecurityKey>();

    options.IncludeErrorDetails = true;
    options.TokenValidationParameters = new()
    {
        // валидация ключа безопасности
        ValidateIssuerSigningKey = true,
        // установка ключа безопасности
        IssuerSigningKey = rsaPublicKey,

        // укзывает, будет ли валидироваться издатель при валидации токена
        ValidateIssuer = false,
        // будет ли валидироваться потребитель токена
        ValidateAudience = false,
        // будет ли валидироваться время существования
        ValidateLifetime = true,

        // будут валидны только подписанные токены
        RequireSignedTokens = true,
        // будут валидны только токены, у которых есть дата устаревания
        RequireExpirationTime = true,
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("local react");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<BookingDbContext>();
    context.Database.EnsureCreated();

    if (app.Environment.EnvironmentName != "Test")
    {
        context.Database.Migrate();
    }
}

app.Run();
