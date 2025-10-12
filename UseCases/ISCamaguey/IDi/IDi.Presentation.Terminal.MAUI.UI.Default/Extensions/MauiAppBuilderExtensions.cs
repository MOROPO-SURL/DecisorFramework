using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.Models.Page.Configuration;
using MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration;
using MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.UI.Default.Extensions
{
    public static class MauiAppBuilderExtensions
    {
        public static Microsoft.Maui.Hosting.MauiAppBuilder UseDecisorUseCaseIDi(this Microsoft.Maui.Hosting.MauiAppBuilder builder)
        {
            builder.Services
                // DetailPage factory resgistration !!!
                .AddSingleton<IDetailContentPageFactoryFacade<ResearchAreaDisplayModel>, ResearchAreaDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<ProgramDisplayModel>, ProgramDetailPageFactory>()

                // ConfigurationPage factory resgistration !!!
                .AddSingleton<IConfigurationContentPageFactoryFacade<ResearchAreaDisplayModel, ResearchAreaConfigurationPageModel>, ResearchAreaConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<ProgramDisplayModel, ProgramConfigurationPageModel>, ProgramConfigurationPageFactory>();

            return builder;
        }
    }
}
