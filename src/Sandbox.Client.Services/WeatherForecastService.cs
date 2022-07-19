using Sandbox.Client.Abstract;
using Sandbox.Model;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace Sandbox.Client.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        readonly HttpClient _http;

        public WeatherForecastService(HttpClient client)
        {
            _http = client;
        }

        public async Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
        {
            return await _http.GetFromJsonAsync<WeatherForecast[]>("WeatherForecast") ?? await Task.FromResult(Array.Empty<WeatherForecast>());
        }
    }
}
