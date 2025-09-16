using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade;
using MOROPO.Framework.Decisor.Leasing.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.Models.Page.Configuration;
using MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration;
using MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Extensions
{
    public static class MauiAppBuilderExtensions
    {
        public static Microsoft.Maui.Hosting.MauiAppBuilder UseDecisorFrameworkLeasing(this Microsoft.Maui.Hosting.MauiAppBuilder builder)
        {
            builder.Services
                // DetailPage factory resgistration !!!
                .AddSingleton<IDetailContentPageFactoryFacade<VehicleLeasePropousalDisplayModel>, VehicleLeasePropousalDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<PropertyLeasePropousalDisplayModel>, PropertyLeasePropousalDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<VehicleLeaseOfferDisplayModel>, VehicleLeaseOfferDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<PropertyLeaseOfferDisplayModel>, PropertyLeaseOfferDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<SupervisionGroupDisplayModel>, SupervisionGroupDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<LegalClientVehicleLeasingDisplayModel>, LegalClientVehicleLeasingDetailPageFactory>()

                // ConfigurationPage factory resgistration !!!
                .AddSingleton<IConfigurationContentPageFactoryFacade<VehicleLeasePropousalDisplayModel, VehicleLeasePropousalConfigurationPageModel>, VehicleLeasePropousalConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<PropertyLeasePropousalDisplayModel, PropertyLeasePropousalConfigurationPageModel>, PropertyLeasePropousalConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<VehicleLeaseOfferDisplayModel, VehicleLeaseOfferConfigurationPageModel>, VehicleLeaseOfferConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<PropertyLeaseOfferDisplayModel, PropertyLeaseOfferConfigurationPageModel>, PropertyLeaseOfferConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<SupervisionGroupDisplayModel, SupervisionGroupConfigurationPageModel>, SupervisionGroupConfigurationPageFactory>();

            return builder;
        }
    }
}
