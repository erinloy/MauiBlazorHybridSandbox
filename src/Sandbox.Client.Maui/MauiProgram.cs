﻿using Microsoft.AspNetCore.Components.WebView.Maui;
using Sandbox.Client.Abstract;
using Sandbox.Client.Maui.Data;

namespace Sandbox.Client.Maui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
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

            builder.Services.AddSingleton<IWeatherForecastService, WeatherForecastService>();

            return builder.Build();
        }
    }
}