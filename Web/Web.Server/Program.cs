var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapFallbackToFile("/index.html"); // map fallback to our index.html which is 

app.Run();
