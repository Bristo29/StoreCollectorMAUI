using Microsoft.Extensions.Logging;
using StoreCollector.Maui;
using StoreCollector.Maui.Services;
using StoreCollector.Maui.ViewModels;
using StoreCollector.Maui.Views;

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

        // 🔥 Aquí registramos todo
        builder.Services.AddSingleton<ApiService>();
        builder.Services.AddSingleton<ProductoService>();

        builder.Services.AddTransient<ProductosViewModel>();
        builder.Services.AddTransient<NuevoProductoViewModel>();

        builder.Services.AddTransient<ProductosPage>();
        builder.Services.AddTransient<NuevoProductoPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
