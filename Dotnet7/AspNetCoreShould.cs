using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Primitives;
using Training_Dotnet8_CSharp12.Csharp11;

namespace Training_Dotnet8_CSharp12.Dotnet7;

public class AspNetCoreMinimalApiShould
{
    public void AllowCreatingMinimalApi(IEndpointRouteBuilder app)
    {
        app.MapGet("/coverage", (int[] ids) => { });
        app.MapGet("/student", (string[] studentIds) => { });
        app.MapGet("/organization", (StringValues organization) => { });
    }

    public void ExposeResultTypes()
    {
        // Now allow for better testing
        Assert.IsType<Ok<Person>>(null);
    }

    public void SupportFormFile(IEndpointRouteBuilder app)
    {
        app.MapPost("/upload", async (IFormFile file) =>
        {
            var tempFile = Path.GetTempFileName();
            using var stream = File.OpenWrite(tempFile);
            await file.CopyToAsync(stream);
        });

        app.MapPost("/upload_many", async (IFormFileCollection myFiles) =>
        {
            foreach (var file in myFiles)
            {
                var tempFile = Path.GetTempFileName();
                using var stream = File.OpenWrite(tempFile);
                await file.CopyToAsync(stream);
            }
        });
    }

    public void AllowComplexTypeWithoutExplicitBinding(IEndpointRouteBuilder app)
    {
        app.MapPost("/change", ([AsParameters] ChangeRequest request) =>
        {
            return Results.Ok(request);
        });
    }

    public void SimplifyRouteGrouping(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/student");

        group.MapGet("/", () => { });
        group.MapGet("/{id}", (int id) => { });
        group.MapPost("/refund", () => { });
    }
}

public class ChangeRequest
{
    public required string Name { get; set; }

    public required int Age { get; set; }
}
