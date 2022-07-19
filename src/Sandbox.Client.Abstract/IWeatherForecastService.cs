using Sandbox.Model;

namespace Sandbox.Client.Abstract
{
    public interface IWeatherForecastService
    {
        Task<WeatherForecast[]> GetForecastAsync(DateTime startDate);
    }
}