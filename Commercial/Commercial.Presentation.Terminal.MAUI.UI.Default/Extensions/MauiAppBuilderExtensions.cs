using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Decisor.Commercial.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Commercial.Presentation.Terminal.MAUI.Models.Page.Configuration;
using MOROPO.Framework.Decisor.Commercial.Presentation.Terminal.MAUI.UI.Default.Factories;
using MOROPO.Framework.Decisor.Commercial.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;
using MOROPO.Framework.Decisor.Commercial.Presentation.Terminal.MAUI.UI.Default.Pages.Detail;
using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade;

namespace MOROPO.Framework.Decisor.Commercial.Presentation.Terminal.MAUI.UI.Default.Extensions
{
    public static class MauiAppBuilderExtensions
    {
        public static Microsoft.Maui.Hosting.MauiAppBuilder UseDecisorFrameworkCommercial(this Microsoft.Maui.Hosting.MauiAppBuilder builder)
        {
            builder.Services
                // DetailPage factory resgistration !!!
                .AddSingleton<IDetailContentPageFactoryFacade<PaymentTermDisplayModel, PaymentTermDetailPage>, PaymentTermDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<LegalProviderDisplayModel, LegalProviderDetailPage>, LegalProviderDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<LegalClientDisplayModel, LegalClientDetailPage>, LegalClientDetailPageFactory>()

                // ConfigurationPage factory resgistration !!!
                .AddSingleton<IConfigurationContentPageFactoryFacade<LegalProviderDisplayModel, LegalProviderConfigurationPageModel, LegalProviderConfigurationPage>, LegalProviderConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<LegalClientDisplayModel, LegalClientConfigurationPageModel, LegalClientConfigurationPage>, LegalClientConfigurationPageFactory>();

            return builder;
        }
    }
}
