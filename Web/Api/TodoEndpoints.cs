using System;
using DotNet9WithSQLite.DB;
using DotNet9WithSQLite.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNet9WithSQLite.Web.Api;

public static class TodoEndpoints
{
    private static string _base => "api/todos";
    private static string _getall => _base;
    private static string _getone => $"{_base}/{{id}}";
    private static string _create => _base;
    private static string _update => _base;
    private static string _delete => $"{_base}/{{id}}";

    public static void MapTodoEndpoints(this WebApplication app) {
        app.MapGet(_getall, GetAllTodos);
        app.MapGet(_getone, GetOneTodo);
        app.MapPost(_create, CreateTodo);
        app.MapPut(_update, UpdateTodo);
        app.MapDelete(_delete, DeleteTodo);
    }

    private static async Task<IResult> DeleteTodo(int id, ToDoDb toDoDb)
    {
        var todo = await toDoDb.toDos.FindAsync(id);
        if (todo is null)
        {
            return Results.NotFound();            
        }
        toDoDb.toDos.Remove(todo);
        await toDoDb.SaveChangesAsync();
        return Results.Ok();
    }

    private static async Task<IResult> UpdateTodo(int id, ToDo updatedToDo, ToDoDb toDoDb)
    {
        var todo = await toDoDb.toDos.FindAsync(id);
        if (todo is null)
        {
            return Results.NotFound();            
        }
        todo.Title = updatedToDo.Title;
        todo.Description = updatedToDo.Description;
        todo.IsComplete = updatedToDo.IsComplete;

        var updatedTodo = await toDoDb.SaveChangesAsync();
        return Results.Ok(todo);
    }

    private static async Task<IResult> CreateTodo(ToDo toDo, ToDoDb toDoDb)
    {
        toDo.CreatedAt = DateTime.Now;
        await toDoDb.toDos.AddAsync(toDo);
        await toDoDb.SaveChangesAsync();
        return Results.Created($"/{_getone.Replace("{id}", toDo.Id.ToString())}", toDo);
    }


    private static async Task<IResult> GetOneTodo(int id, ToDoDb toDoDb)
    {
        var todo = await toDoDb.toDos.FindAsync(id);
        if (todo is null)
        {
            return Results.NotFound();            
        }
        return Results.Ok(todo);
    }

    private static async Task<IResult> GetAllTodos(ToDoDb toDoDb)
    {
        var todos = await toDoDb.toDos.ToListAsync();
        return Results.Ok(todos);
    }


}
