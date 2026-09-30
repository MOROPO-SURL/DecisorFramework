using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade;
using MOROPO.ISCamaguey.Decisor.Production.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.Production.Presentation.Terminal.MAUI.Models.Page.Configuration;
using MOROPO.ISCamaguey.Decisor.Production.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration;
using MOROPO.ISCamaguey.Decisor.Production.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;

namespace MOROPO.ISCamaguey.Decisor.Production.Presentation.Terminal.MAUI.UI.Default.Extensions;

public static class MauiAppBuilderExtensions
{
    public static Microsoft.Maui.Hosting.MauiAppBuilder UseDecisorUseCaseProduction(this Microsoft.Maui.Hosting.MauiAppBuilder builder)
    {
        builder.Services
            // DetailPage factory resgistration !!!
            .AddSingleton<IDetailContentPageFactoryFacade<ProductionQualityCheckDisplayModel>, ProductionQualityCheckDetailPageFactory>()

            // ConfigurationPage factory resgistration !!!
            .AddSingleton<IConfigurationContentPageFactoryFacade<ProductionQualityCheckDisplayModel, ProductionQualityCheckConfigurationPageModel>, ProductionQualityCheckConfigurationPageFactory>();

        return builder;
    }
}