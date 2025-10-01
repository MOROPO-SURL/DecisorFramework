using CommunityToolkit.Maui;
using Maui.FreakyControls.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using MOROPO.Framework.Decisor.Commercial.Presentation.Terminal.MAUI.UI.Default.Extensions;
using MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Extensions;
using MOROPO.Framework.Decisor.Financial.Presentation.Terminal.MAUI.UI.Default.Extensions;
using MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Extensions;
using MOROPO.Framework.Decisor.Legal.Presentation.Terminal.MAUI.UI.Default.Extensions;
using MOROPO.Framework.Decisor.Production.Presentation.Terminal.MAUI.UI.Default.Extensions;
using MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.UI.Default.Extensions;
using SkiaSharp.Views.Maui.Controls.Hosting;

namespace MOROPO.ISCamaguey.Decisor.Terminal
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
               .UseMauiCommunityToolkit()
               .UseMauiCommunityToolkitMediaElement()
               .UseSkiaSharp()
               .ConfigureFonts(fonts =>
               {
                   fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                   fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                   fonts.AddFont("materialdesignicons-webfont.ttf", "MaterialDesignIcons");
               })
               .InitializeFreakyControls()
               .UseDecisorFrameworkDomain()
               .UseDecisorFrameworkLegal()
               .UseDecisorFrameworkHumanResources()
               .UseDecisorFrameworkFinancial()
               .UseDecisorFrameworkProduction()
               .UseDecisorFrameworkCommercial()
               .UseDecisorUseCaseIDi()
               .Services
                   .AddSingleton<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade, Providers.HttpClientHelperProvider>()
                   .AddSingleton<Framework.Decisor.Core.Presentation.Terminal.MAUI.Providers.Facade.IRuntimeContextProviderFacade, Providers.SingleRuntimeContextProvider>()
                   .AddSingleton<Framework.Decisor.Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade, Helpers.MainExceptionHandlingHelper>()
                   .AddSingleton<Framework.Decisor.Core.Presentation.Terminal.MAUI.Managers.Facade.ISessionManagerFacade, Framework.Decisor.Core.Presentation.Terminal.MAUI.Managers.DefaultSessionManager>();
#if DEBUG
            builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
    }
}