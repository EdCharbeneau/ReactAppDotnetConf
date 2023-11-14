using Microsoft.AspNetCore.Components.Web;
using ReactAppDotnetConf.Server.Components;
using ReactAppDotnetConf.Server.Services;
using System.Diagnostics.Metrics;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IWeatherService, WeatherService>();
builder.Services.AddControllersWithViews();
// Add services to the container.
builder.Services.AddServerSideBlazor(options =>
{
	options.RootComponents.RegisterCustomElement<BlazorForecast>("blazor-forecast");
});

var app = builder.Build();



// Configure the HTTP request pipeline.
app.UseDefaultFiles();
app.UseStaticFiles();
app.UseHttpsRedirection();

app.MapGet("/weatherforecast", (IWeatherService service) =>
{
    return service.GetWeather();
});

app.UseRouting();
app.MapBlazorHub();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();

public record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
	public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
