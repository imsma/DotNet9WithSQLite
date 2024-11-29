using DotNet9WithSQLite.DB;
using DotNet9WithSQLite.Web.Api;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ToDos") ?? "Data Source=ToDos.db";
builder.Services.AddSqlite<ToDoDb>(connectionString);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo{
        Title = "ToDos API",
        Version = "v1",
        Description = "A simple API to manage ToDos"
    });
});


var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI(c => {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "ToDos API V1");
    });
}

app.MapGet("/", () => "Hello World!");
app.MapTodoEndpoints();

app.Run();
