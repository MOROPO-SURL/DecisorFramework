using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Decisor.Commercial.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Commercial.Presentation.Terminal.MAUI.Models.Page.Configuration;
using MOROPO.Framework.Decisor.Commercial.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration;
using MOROPO.Framework.Decisor.Commercial.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;
using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade;

namespace MOROPO.Framework.Decisor.Commercial.Presentation.Terminal.MAUI.UI.Default.Extensions
{
    public static class MauiAppBuilderExtensions
    {
        public static Microsoft.Maui.Hosting.MauiAppBuilder UseDecisorFrameworkCommercial(this Microsoft.Maui.Hosting.MauiAppBuilder builder)
        {
            builder.Services
                // DetailPage factory resgistration !!!
                .AddSingleton<IDetailContentPageFactoryFacade<PaymentTermDisplayModel>, PaymentTermDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<LegalProviderDisplayModel>, LegalProviderDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<LegalClientDisplayModel>, LegalClientDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<NaturalProviderDisplayModel>, NaturalProviderDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<NaturalClientDisplayModel>, NaturalClientDetailPageFactory>()

                // ConfigurationPage factory resgistration !!!
                .AddSingleton<IConfigurationContentPageFactoryFacade<LegalProviderDisplayModel, LegalProviderConfigurationPageModel>, LegalProviderConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<LegalClientDisplayModel, LegalClientConfigurationPageModel>, LegalClientConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<NaturalProviderDisplayModel, NaturalProviderConfigurationPageModel>, NaturalProviderConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<NaturalClientDisplayModel, NaturalClientConfigurationPageModel>, NaturalClientConfigurationPageFactory>();

            return builder;
        }
    }
}
