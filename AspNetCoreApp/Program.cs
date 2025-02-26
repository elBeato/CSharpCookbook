// Old version before ASP.NET 6: WebHostBuilder()
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();

//Get values from appsettings.json
var customAppsettings = builder.Configuration.GetSection("MyApplicationName").Value;
var customAppsettings2 = builder.Configuration["MyApplicationName"];
Console.WriteLine($"Read appsettings.json: {customAppsettings}");
Console.WriteLine($"Read appsettings.json: {customAppsettings2}");



Console.WriteLine("\n=== Build host ===\n");

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
