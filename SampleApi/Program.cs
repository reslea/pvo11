using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SampleApi;
using System.Security.Cryptography;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(1);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = false;
    options.Cookie.Name = "Session";
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var config = builder.Services.BuildServiceProvider().GetRequiredService<IConfiguration>();
        var pubicKey = config["Jwt:Public"];

        RSA rsa = RSA.Create();
        var publicKeyBytes = Convert.FromBase64String(pubicKey);
        rsa.ImportRSAPublicKey(publicKeyBytes, out var _);

        var rsaKey = new RsaSecurityKey(rsa);

        options.IncludeErrorDetails = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new()
        {
            // укзывает, будет ли валидироваться издатель при валидации токена
            ValidateIssuer = false,
            // будет ли валидироваться потребитель токена
            ValidateAudience = false,
            // будет ли валидироваться время существования
            ValidateLifetime = true,

            // установка ключа безопасности
            IssuerSigningKey = rsaKey,
            // валидация ключа безопасности
            ValidateIssuerSigningKey = true,
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

app.UseSession();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<RequestLanguageMiddleware>();

app.Run();
