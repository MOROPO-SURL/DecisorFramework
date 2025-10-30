using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade;
using MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.Models.Page.Configuration;
using MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration;
using MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;

namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.UI.Default.Extensions
{
    public static class MauiAppBuilderExtensions
    {
        public static Microsoft.Maui.Hosting.MauiAppBuilder UseDecisorFrameworkPurchasing(this Microsoft.Maui.Hosting.MauiAppBuilder builder)
        {
            builder.Services
                // DetailPage factory resgistration !!!
                .AddSingleton<IDetailContentPageFactoryFacade<PurchaseZoneDisplayModel>, PurchaseZoneDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<PurchaseSpentDisplayModel>, PurchaseSpentDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<PurchaseRequestDisplayModel>, PurchaseRequestDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<PurchaseOrderDisplayModel>, PurchaseOrderDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<LegalProviderBudgetDisplayModel>, LegalProviderBudgetDetailPageFactory>()

                // ConfigurationPage factory resgistration !!!
                .AddSingleton<IConfigurationContentPageFactoryFacade<PurchaseZoneDisplayModel, PurchaseZoneConfigurationPageModel>, PurchaseZoneConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<PurchaseSpentDisplayModel, PurchaseSpentConfigurationPageModel>, PurchaseSpentConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<PurchaseRequestDisplayModel, PurchaseRequestConfigurationPageModel>, PurchaseRequestConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<PurchaseOrderDisplayModel, PurchaseOrderConfigurationPageModel>, PurchaseOrderConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<LegalProviderBudgetDisplayModel, LegalProviderBudgetConfigurationPageModel>, LegalProviderBudgetConfigurationPageFactory>();

            return builder;
        }
    }
}
