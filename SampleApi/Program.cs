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

builder.Services.AddSingleton(provider =>
{
    var config = builder.Services.BuildServiceProvider().GetRequiredService<IConfiguration>();
    var pubicKey = config["Jwt:Public"];

    RSA rsa = RSA.Create();
    var publicKeyBytes = Convert.FromBase64String(pubicKey);
    rsa.ImportRSAPublicKey(publicKeyBytes, out var _);

    return new RsaSecurityKey(rsa);
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var rsaPublicKey = builder.Services.BuildServiceProvider()
        .GetRequiredService<RsaSecurityKey>();
#if DEBUG
        options.IncludeErrorDetails = true;
#endif
        options.TokenValidationParameters = new()
        {
            // установка ключа безопасности
            IssuerSigningKey = rsaPublicKey,
            // валидация ключа безопасности
            ValidateIssuerSigningKey = true,

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

app.UseSession();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<RequestLanguageMiddleware>();

app.Run();
