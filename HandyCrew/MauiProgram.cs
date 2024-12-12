
using CommunityToolkit.Maui;
using HandyCrew.Models;
using HandyCrew.Services;
using Microsoft.Extensions.Logging;
using Mopups.Hosting;
using Xamarin.Essentials;
using UraniumUI;

namespace HandyCrew
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseUraniumUI()
                .UseUraniumUIMaterial()
                .ConfigureMopups()
                .UseMauiCommunityToolkit()
                

                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<LocationSyncService>();
            builder.Services.AddHttpClient<LocationHQService>();
            builder.Services.AddMopupsDialogs();
            builder.Services.AddCommunityToolkitDialogs();
           


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();



        }
    }
}
