using System.Data.SqlClient;
using Dapper;
using SimpleTodoApp.DomainServices;
using SimpleTodoApp.Infrastructure;
using SimpleTodoApp.Model;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<ITodoItemRepository, TodoItemRepository>();

const string connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Todo;Integrated Security=True";
var sqlConnectionFactory = new SqlConnectionFactory(connStr);
builder.Services.AddSingleton(sqlConnectionFactory);

var app = builder.Build();


app.MapGet("/todo", async (ITodoItemRepository repo) =>
{
    return repo.GetAll();
});
app.MapPost("/todo", async (TodoItem todoItem, ITodoItemRepository repo) =>
{
    return await repo.Create(todoItem);
});
app.MapPut("/todo", async (TodoItem todoItem, ITodoItemRepository repo) =>
{
    todoItem.Done = DateTime.Today;
    return await repo.Update(todoItem);
});
app.MapDelete("/todo/{id}", async (Guid id, ITodoItemRepository repo) =>
{
    await repo.Delete(id);
});

app.UseStaticFiles();
app.Run();
