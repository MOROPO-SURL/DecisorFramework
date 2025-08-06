using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.Models.Page.Configuration;
using MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration;
using MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;
using MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;
using MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Pages.Detail;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Extensions
{
    public static class MauiAppBuilderExtensions
    {
        public static Microsoft.Maui.Hosting.MauiAppBuilder UseDecisorFrameworkLeasing(this Microsoft.Maui.Hosting.MauiAppBuilder builder)
        {
            builder.Services
                // DetailPage factory resgistration !!!
                .AddSingleton<IDetailContentPageFactoryFacade<VehicleLeasePropousalDisplayModel, VehicleLeasePropousalDetailPage>, VehicleLeasePropousalDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<PropertyLeasePropousalDisplayModel, PropertyLeasePropousalDetailPage>, PropertyLeasePropousalDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<VehicleLeaseOfferDisplayModel, VehicleLeaseOfferDetailPage>, VehicleLeaseOfferDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<PropertyLeaseOfferDisplayModel, PropertyLeaseOfferDetailPage>, PropertyLeaseOfferDetailPageFactory>()

                // ConfigurationPage factory resgistration !!!
                .AddSingleton<IConfigurationContentPageFactoryFacade<VehicleLeasePropousalDisplayModel, VehicleLeasePropousalConfigurationPageModel, VehicleLeasePropousalConfigurationPage>, VehicleLeasePropousalConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<PropertyLeasePropousalDisplayModel, PropertyLeasePropousalConfigurationPageModel, PropertyLeasePropousalConfigurationPage>, PropertyLeasePropousalConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<VehicleLeaseOfferDisplayModel, VehicleLeaseOfferConfigurationPageModel, VehicleLeaseOfferConfigurationPage>, VehicleLeaseOfferConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<PropertyLeaseOfferDisplayModel, PropertyLeaseOfferConfigurationPageModel, PropertyLeaseOfferConfigurationPage>, PropertyLeaseOfferConfigurationPageFactory>();

            return builder;
        }
    }
}
