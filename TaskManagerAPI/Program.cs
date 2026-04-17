var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var tasks = new List<string>();

// Get all tasks
app.MapGet("/tasks", () => tasks);

// Add task
app.MapPost("/tasks", (string task) =>
{
    tasks.Add(task);
    return Results.Ok("Task added");
});

// Delete task
app.MapDelete("/tasks/{id}", (int id) =>
{
    if (id < 0 || id >= tasks.Count)
        return Results.NotFound("Task not found");

    tasks.RemoveAt(id);
    return Results.Ok("Task deleted");
});

app.Run();
