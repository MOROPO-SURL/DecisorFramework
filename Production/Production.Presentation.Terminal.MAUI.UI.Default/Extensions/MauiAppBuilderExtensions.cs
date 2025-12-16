using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade;
using MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Production.Presentation.Terminal.MAUI.Models.Page.Configuration;
using MOROPO.Framework.Decisor.Production.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration;
using MOROPO.Framework.Decisor.Production.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;

namespace MOROPO.Framework.Decisor.Production.Presentation.Terminal.MAUI.UI.Default.Extensions
{
    public static class MauiAppBuilderExtensions
    {
        public static Microsoft.Maui.Hosting.MauiAppBuilder UseDecisorFrameworkProduction(this Microsoft.Maui.Hosting.MauiAppBuilder builder)
        {
            builder.Services
                // DetailPage factory resgistration !!!
                .AddSingleton<IDetailContentPageFactoryFacade<ProductionOrderDisplayModel>, ProductionOrderDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<ElaborationDisplayModel>, ElaborationDetailPageFactory>()

                // ConfigurationPage factory resgistration !!!
                .AddSingleton<IConfigurationContentPageFactoryFacade<ProductionOrderDisplayModel, ProductionOrderConfigurationPageModel>, ProductionOrderConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<ElaborationDisplayModel, ElaborationConfigurationPageModel>, ElaborationConfigurationPageFactory>();

            return builder;
        }
    }
}
