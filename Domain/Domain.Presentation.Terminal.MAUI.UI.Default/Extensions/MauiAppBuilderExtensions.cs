using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.Models.Page.Configuration;
using MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration;
using MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;
using MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;
using MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Detail;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Extensions
{
    public static class MauiAppBuilderExtensions
    {
        public static Microsoft.Maui.Hosting.MauiAppBuilder UseDecisorFrameworkDomain(this Microsoft.Maui.Hosting.MauiAppBuilder builder)
        {
            builder.Services
                // DetailPage factory resgistration !!!
                .AddSingleton<IDetailContentPageFactoryFacade<PersonContactDisplayModel, PersonContactDetailPage>, PersonContactDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<OrganizationContactDisplayModel, OrganizationContactDetailPage>, OrganizationContactDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<NaturalBusinessKindDisplayModel, NaturalBusinessKindDetailPage>, NaturalBusinessKindDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<LegalBusinessKindDisplayModel, LegalBusinessKindDetailPage>, LegalBusinessKindDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<PropertyDisplayModel, PropertyDetailPage>, PropertyDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<VehicleKindDisplayModel, VehicleKindDetailPage>, VehicleKindDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<VehicleEngineKindDisplayModel, VehicleEngineKindDetailPage>, VehicleEngineKindDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<BrandDisplayModel, BrandDetailPage>, BrandDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<VehicleDisplayModel, VehicleDetailPage>, VehicleDetailPageFactory>()

                // ConfigurationPage factory resgistration !!!
                .AddSingleton<IConfigurationContentPageFactoryFacade<PersonContactDisplayModel, PersonContactConfigurationPageModel, PersonContactConfigurationPage>, PersonContactConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<PersonContactDisplayModel, PersonContactConfigurationPageModel, PersonContactConfigurationPage>, PersonContactConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<OrganizationContactDisplayModel, OrganizationContactConfigurationPageModel, OrganizationContactConfigurationPage>, OrganizationContactConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<PropertyDisplayModel, PropertyConfigurationPageModel, PropertyConfigurationPage>, PropertyConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<BrandDisplayModel, BrandConfigurationPageModel, BrandConfigurationPage>, BrandConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<VehicleDisplayModel, VehicleConfigurationPageModel, VehicleConfigurationPage>, VehicleConfigurationPageFactory>();
                
            return builder;
        }
    }
}
