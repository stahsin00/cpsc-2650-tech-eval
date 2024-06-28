# Notes

## Basics

### .NET SDK

Must have the .NET SDK installed to build and run the project.

### ASP.NET Core

Specifically used for web applications.

### C#

The primary language used in ASP.NET Core.

## Frameworks

### Microsoft.EntityFrameworkCore

Entity Framework is a helpful tool to interact with databases.

> **Compares to Node.js**
>
> In Node.js, we can use arrays or other data structures to store data in memory.
>
> In ASP.NET Core, we typically define a data context class to interact with a database.

#### DbContext

Data context is crucial for managing the database operations for the entities (like `TodoItem`) within the application.

- `UseInMemoryDatabase()`: data is stored in memory, will be lost when the app is closed.
- `UseSqlServer()`: data is stored in a SQL Server database.
- `UseSqlite()`: data is stored in a SQLite database.

#### DbSet

A collection of entities of a specific type (like `TodoItem`).

## Important Files

### Startup.cs

`Startup.cs` is the entry point of the application. It configures services and the request pipeline.

### Models

Contains the data model classes

### Controllers

Handles incoming HTTP requests

```csharp
[HttpGet]
public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems()
{
    return await _context.TodoItems.ToListAsync();
}
```

- `HttpGet`: specifies the HTTP method
- `async Task<ActionResult<IEnumerable<TodoItem>>>`: specifies the return type
  - `async Task`: allows the method to be asynchronous
  - `ActionResult`: wraps the return value
  - `IEnumerable<TodoItem>`: the actual return value
