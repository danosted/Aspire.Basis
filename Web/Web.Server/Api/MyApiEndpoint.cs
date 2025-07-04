using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WebServer.Api;

public static class MyApiEndpoint
{
    public static WebApplication MapEndpoints(this WebApplication app)
    {
        var grp = app.MapGroup("v1");
            
        grp.MapGet("/api/my-endpoint", GetMyModelAsync)
            .WithName("My Endpoint");
        return app;
    }

    public static async Task<Results<Ok<MyModel>,BadRequest<ProblemDetails>>> GetMyModelAsync()
    {
        await Task.Delay(500);

        var model = new MyModel
        {
            Name = "Aspire",
            Age = Random.Shared.Next()
        };

        return TypedResults.Ok(model);

    }
}

public class MyModel
{
    public required string Name { get; init; } = string.Empty;
    public int? Age { get; init; }
}