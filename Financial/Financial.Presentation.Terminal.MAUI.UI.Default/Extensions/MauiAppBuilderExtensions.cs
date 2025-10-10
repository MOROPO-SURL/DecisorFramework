using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade;
using MOROPO.Framework.Decisor.Financial.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Financial.Presentation.Terminal.MAUI.Models.Page.Configuration;
using MOROPO.Framework.Decisor.Financial.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration;
using MOROPO.Framework.Decisor.Financial.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;

namespace MOROPO.Framework.Decisor.Financial.Presentation.Terminal.MAUI.UI.Default.Extensions
{
    public static class MauiAppBuilderExtensions
    {
        public static Microsoft.Maui.Hosting.MauiAppBuilder UseDecisorFrameworkFinancial(this Microsoft.Maui.Hosting.MauiAppBuilder builder)
        {
            builder.Services
                // DetailPage factory resgistration !!!
                .AddSingleton<IDetailContentPageFactoryFacade<BankAgencyDisplayModel>, BankAgencyDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<CurrencyDisplayModel>, CurrencyDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<BankBranchDisplayModel>, BankBranchDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<BankAccountDisplayModel>, BankAccountDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<CostCenterDisplayModel>, CostCenterDetailPageFactory>()

                // ConfigurationPage factory resgistration !!!
                .AddSingleton<IConfigurationContentPageFactoryFacade<BankAgencyDisplayModel, BankAgencyConfigurationPageModel>, BankAgencyConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<CurrencyDisplayModel, CurrencyConfigurationPageModel>, CurrencyConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<BankBranchDisplayModel, BankBranchConfigurationPageModel>, BankBranchConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<BankAccountDisplayModel, BankAccountConfigurationPageModel>, BankAccountConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<CostCenterDisplayModel, CostCenterConfigurationPageModel>, CostCenterConfigurationPageFactory>();

            return builder;
        }
    }
}
