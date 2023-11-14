using System;

namespace ReactAppDotnetConf.Server.Services
{
    public class WeatherService : IWeatherService
    {
        private string[] summaries => new[]
                {
                    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
                };
        public Task<WeatherForecast[]> GetWeather() => Task.Run(()=>Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray());
    }
}
