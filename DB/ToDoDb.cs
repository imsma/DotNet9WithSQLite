using System;
using DotNet9WithSQLite.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNet9WithSQLite.DB;

public class ToDoDb  : DbContext
{
    public ToDoDb(DbContextOptions<ToDoDb> options) : base(options) { }
    public DbSet<ToDo> toDos { get; set; } = null!;


}
