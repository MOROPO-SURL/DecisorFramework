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

                // ConfigurationPage factory resgistration !!!
                .AddSingleton<IConfigurationContentPageFactoryFacade<BankAgencyDisplayModel, BankAgencyConfigurationPageModel>, BankAgencyConfigurationPageFactory>();

            return builder;
        }
    }
}
