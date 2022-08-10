using Microsoft.AspNetCore.SignalR;
using SignalrSample;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthorization();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSignalR();

builder.Services.AddCors(opts => opts.AddPolicy("react", policy => policy
        .WithOrigins("http://localhost:3000")
        .AllowAnyMethod()
        .AllowCredentials()
        .AllowAnyHeader()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapHub<ChatHub>("/chatHub");


app.MapPost("chat/message", async (
    MessageModel model,
    IHubContext<ChatHub, IChatHubClient> chatContext) => { 
        await chatContext.Clients.All.ReceiveMessage(model.Name, model.Message);
});

app.UseCors("react");

app.UseAuthorization();

app.Run();

record MessageModel(string Name, string Message);
