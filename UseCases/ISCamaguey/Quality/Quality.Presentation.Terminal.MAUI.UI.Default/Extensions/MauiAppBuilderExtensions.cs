using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade;
using MOROPO.ISCamaguey.Decisor.Quality.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.Quality.Presentation.Terminal.MAUI.Models.Page.Configuration;
using MOROPO.ISCamaguey.Decisor.Quality.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration;
using MOROPO.ISCamaguey.Decisor.Quality.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;

namespace MOROPO.ISCamaguey.Decisor.Quality.Presentation.Terminal.MAUI.UI.Default.Extensions
{
    public static class MauiAppBuilderExtensions
    {
        public static Microsoft.Maui.Hosting.MauiAppBuilder UseDecisorUseCaseQuality(this Microsoft.Maui.Hosting.MauiAppBuilder builder)
        {
            builder.Services
                // DetailPage factory resgistration !!!
                .AddSingleton<IDetailContentPageFactoryFacade<IsoStandardDisplayModel>, IsoStandardDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<CubanStandardDisplayModel>, CubanStandardDetailPageFactory>()

                // ConfigurationPage factory resgistration !!!
                .AddSingleton<IConfigurationContentPageFactoryFacade<IsoStandardDisplayModel, IsoStandardConfigurationPageModel>, IsoStandardConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<CubanStandardDisplayModel, CubanStandardConfigurationPageModel>, CubanStandardConfigurationPageFactory>();

            return builder;
        }
    }
}
