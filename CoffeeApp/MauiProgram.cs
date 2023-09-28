using CoffeeApp.Basket;
using CoffeeApp.CoffeeList;
using CoffeeApp.DetailedCoffee;
using CoffeeApp.MainPage;
using CoffeeApp.Services;
using Microsoft.Extensions.Logging;

namespace CoffeeApp
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
            builder.Services.AddSingleton<MainPageViewModel>();
            builder.Services.AddSingleton<MainPageView>();

            builder.Services.AddTransient<DetailedCoffeeViewModel>();
            builder.Services.AddTransient<DetailedCoffeeView>();

            builder.Services.AddTransient<CoffeeListViewModel>();
            builder.Services.AddTransient<CoffeeListView>();

            builder.Services.AddTransient<BasketViewModel>();
            builder.Services.AddTransient<BasketView>();

            builder.Services.AddSingleton<CoffeeService>();
            builder.Services.AddSingleton<LoginService>();
            builder.Services.AddSingleton<TokenService>();

            return builder.Build();
        }
    }
}