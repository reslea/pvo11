using Booking.Data;
using Booking.Services;
using Microsoft.EntityFrameworkCore;

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
builder.Services.AddDbContext<BookingDbConext>(options => 
{
    var connectionString = config.GetConnectionString("BookingDb");
    options.UseSqlServer(connectionString);
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

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<BookingDbConext>();
    context.Database.EnsureCreated();
}

app.Run();
