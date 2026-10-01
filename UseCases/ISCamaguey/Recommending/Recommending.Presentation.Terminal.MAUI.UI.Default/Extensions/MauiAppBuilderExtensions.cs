using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade;
using MOROPO.ISCamaguey.Decisor.Recommending.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.Recommending.Presentation.Terminal.MAUI.Models.Page.Configuration;
using MOROPO.ISCamaguey.Decisor.Recommending.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration;
using MOROPO.ISCamaguey.Decisor.Recommending.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;

namespace MOROPO.ISCamaguey.Decisor.Recommending.Presentation.Terminal.MAUI.UI.Default.Extensions;

public static class MauiAppBuilderExtensions
{
    public static Microsoft.Maui.Hosting.MauiAppBuilder UseDecisorUseCaseRecommending(this Microsoft.Maui.Hosting.MauiAppBuilder builder)
    {
        builder.Services
            // DetailPage factory resgistration !!!
            .AddSingleton<IDetailContentPageFactoryFacade<RecomendationReportDisplayModel>, RecomendationReportDetailPageFactory>()

            // ConfigurationPage factory resgistration !!!
            .AddSingleton<IConfigurationContentPageFactoryFacade<RecomendationReportDisplayModel, RecomendationReportConfigurationPageModel>, RecomendationReportConfigurationPageFactory>();

        return builder;
    }
}