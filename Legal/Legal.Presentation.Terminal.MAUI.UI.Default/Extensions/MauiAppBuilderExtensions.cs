using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade;
using MOROPO.Framework.Decisor.Legal.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Legal.Presentation.Terminal.MAUI.Models.Page.Configuration;
using MOROPO.Framework.Decisor.Legal.Presentation.Terminal.MAUI.UI.Default.Factories;
using MOROPO.Framework.Decisor.Legal.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;
using MOROPO.Framework.Decisor.Legal.Presentation.Terminal.MAUI.UI.Default.Pages.Detail;

namespace MOROPO.Framework.Decisor.Legal.Presentation.Terminal.MAUI.UI.Default.Extensions
{
    public static class MauiAppBuilderExtensions
    {
        public static Microsoft.Maui.Hosting.MauiAppBuilder UseDecisorFrameworkLegal(this Microsoft.Maui.Hosting.MauiAppBuilder builder)
        {
            builder.Services
                // DetailPage factory resgistration !!!
                .AddSingleton<IDetailContentPageFactoryFacade<SectionDisplayModel, SectionDetailPage>, SectionDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<ProformaDisplayModel, ProformaDetailPage>, ProformaDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<ClauseDisplayModel, ClauseDetailPage>, ClauseDetailPageFactory>()

                // ConfigurationPage factory resgistration !!!
                .AddSingleton<IConfigurationContentPageFactoryFacade<SectionDisplayModel, SectionConfigurationPageModel, SectionConfigurationPage>, SectionConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<ProformaDisplayModel, ProformaConfigurationPageModel, ProformaConfigurationPage>, ProformaConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<ClauseDisplayModel, ClauseConfigurationPageModel, ClauseConfigurationPage>, ClauseConfigurationPageFactory>();
                
            return builder;
        }
    }
}
