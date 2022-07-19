using Microsoft.AspNetCore.Components.WebView.Maui;
using Sandbox.Client.Abstract;
//using Sandbox.Client.Maui.Data;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Sandbox.Client.Services;


namespace Sandbox.Client.Maui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var a = Assembly.GetExecutingAssembly();
            using var stream = a.GetManifestResourceStream("Sandbox.Client.Maui.appsettings.json");


            var config = new ConfigurationBuilder()
                .AddJsonStream(stream)
                .Build();

            var settings = config.GetRequiredSection("Settings").Get<Code.Settings>();

            var builder = MauiApp.CreateBuilder();
            builder.Configuration.AddConfiguration(config);

            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });


            builder.Services.AddMauiBlazorWebView();
#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
#endif

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(settings.BaseUrl) });

            builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>();

            return builder.Build();
        }
    }
}