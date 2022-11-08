using System.Data.SqlClient;
using Dapper;
using SimpleTodoApp.Model;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
const string connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Todo;Integrated Security=True";

app.MapGet("/todo", async () =>
{

});
app.MapPost("/todo", async (TodoItem todoItem) =>
{

});
app.MapPut("/todo", async (TodoItem todoItem) =>
{
    todoItem.Done = DateTime.Today;

});
app.MapDelete("/todo/{id}", async (Guid id) =>
{

});

app.UseStaticFiles();
app.Run();
