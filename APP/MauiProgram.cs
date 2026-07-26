using Blazored.LocalStorage;
using Microsoft.Extensions.Logging;

namespace APP
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
            builder.Services.AddScoped(sp =>
            {
                return new HttpClient
                {
                    BaseAddress = new Uri("https://testingapi.sjsgold.com/api/")
                };
            });
            builder.Services.AddAntDesign();
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddScoped<GlobalModalAlertService>();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Services.AddScoped(sp =>
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri("https://testingapi.sjsgold.com/api/");
                return client;
            });

            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
