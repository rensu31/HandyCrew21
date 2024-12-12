using HandyCrew.Models;
using HandyCrew.Models.ViewModels;
using HandyCrew.Services;
using HandyCrew.Views;
using Microsoft.Extensions.DependencyInjection;

namespace HandyCrew
{
    public partial class App : Application
    {
        public static FileResult _mainimgResult;
        public static string UserkeyUser, fullNameuSER, key;
        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            var locationSyncService = serviceProvider.GetRequiredService<LocationSyncService>();
            var locationHQService = serviceProvider.GetRequiredService<LocationHQService>();
            var mainPageViewModel = new MainpageViewModel(locationHQService);

            MainPage = new AppShell();
        }
    }
}
