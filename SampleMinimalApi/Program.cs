using SampleMinimalApi.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddScoped<UserDbContext>();

builder.Services.AddCors(option =>
{
    option.AddPolicy("all", policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var todos = new List<TodoModel>()
{
    new () { Id = 1, Title = "First"  },
    new () { Id = 2, Title = "Second"  },
    new () { Id = 3, Title = "Third"  },
    new () { Id = 4, Title = "Fourth"  },
};

app.MapGet("/todo", (ILogger<Program> logger) => {
    logger.LogInformation("all todos");
    return todos;
});

app.MapGet("/todo/{todoId}", (int todoId)
    => todos.FirstOrDefault(x => x.Id == todoId));

app.MapPost("/todo", (TodoModel model) => {
    todos.Add(model);
    return Results.Ok(model);
});

app.MapDelete("/todo/{todoId}", (int todoId) =>
{
    var todo = todos.FirstOrDefault(x => x.Id == todoId);
    
    if (todo == null) return Results.NotFound();
    
    todos.Remove(todo);
    return Results.NoContent();
});

app.UseCors("all");

app.Run();