using Microsoft.Extensions.Logging;
using SaveUpArda.ViewModels;
using SaveUpArda.Views;

namespace SaveUpArda
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            // ViewModels registrieren
            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddTransient<AddItemViewModel>();
            builder.Services.AddTransient<ItemsListViewModel>();

            // Pages registrieren
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<AddItemPage>();
            builder.Services.AddTransient<ItemsListPage>();

            return builder.Build();
        }
    }
}
