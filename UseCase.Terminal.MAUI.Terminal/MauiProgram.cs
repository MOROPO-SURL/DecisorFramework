using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using CommunityToolkit.Maui;

namespace MOROPO.Framework.Decisor.UseCase.Terminal.MAUI;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UseMauiCommunityToolkitMediaElement()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            })
            .Services
                .AddSingleton<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade, Providers.HttpClientHelperProvider>()
                .AddSingleton<Core.Presentation.Terminal.MAUI.Managers.Facade.ISessionManagerFacade, Core.Presentation.Terminal.MAUI.Managers.DefaultSessionManager>();

#if DEBUG
        builder.Logging.AddDebug();
#endif
        return builder.Build();
    }
}