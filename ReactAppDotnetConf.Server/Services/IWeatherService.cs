namespace ReactAppDotnetConf.Server.Services
{
    public interface IWeatherService
    {
        Task<WeatherForecast[]> GetWeather();
    }
}