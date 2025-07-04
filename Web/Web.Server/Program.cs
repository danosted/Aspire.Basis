using Scalar.AspNetCore;
using WebServer.Api;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddOpenApi();
builder.Services.AddProblemDetails();
builder.Services.AddCors();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.MapOpenApi();
    app.MapScalarApiReference();
}
else
{
    app.UseExceptionHandler("/error");
}

app.UseCors(o =>
{
    if (app.Environment.IsDevelopment())
    {
        o.AllowAnyOrigin();
    }
});

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseStatusCodePages();

app.MapEndpoints();

app.MapFallbackToFile("/index.html");

app.Run();
