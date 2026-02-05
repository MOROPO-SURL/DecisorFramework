using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.Models.Page.Configuration;
using MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration;
using MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Extensions
{
    public static class MauiAppBuilderExtensions
    {
        public static Microsoft.Maui.Hosting.MauiAppBuilder UseDecisorFrameworkDomain(this Microsoft.Maui.Hosting.MauiAppBuilder builder)
        {
            builder.Services
                // DetailPage factory resgistration !!!
                .AddSingleton<IDetailContentPageFactoryFacade<PersonContactDisplayModel>, PersonContactDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<OrganizationContactDisplayModel>, OrganizationContactDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<NaturalBusinessKindDisplayModel>, NaturalBusinessKindDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<LegalBusinessKindDisplayModel>, LegalBusinessKindDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<PropertyDisplayModel>, PropertyDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<VehicleKindDisplayModel>, VehicleKindDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<VehicleEngineKindDisplayModel>, VehicleEngineKindDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<BrandDisplayModel>, BrandDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<VehicleDisplayModel>, VehicleDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<EmployeeDisplayModel>, EmployeeDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<UnitMeasurementDisplayModel>, UnitMeasurementDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<KnowledgeAreaDisplayModel>, KnowledgeAreaDetailPageFactory>()

                // ConfigurationPage factory resgistration !!!
                .AddSingleton<IConfigurationContentPageFactoryFacade<PersonContactDisplayModel, PersonContactConfigurationPageModel>, PersonContactConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<PersonContactDisplayModel, PersonContactConfigurationPageModel>, PersonContactConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<OrganizationContactDisplayModel, OrganizationContactConfigurationPageModel>, OrganizationContactConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<PropertyDisplayModel, PropertyConfigurationPageModel>, PropertyConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<BrandDisplayModel, BrandConfigurationPageModel>, BrandConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<VehicleDisplayModel, VehicleConfigurationPageModel>, VehicleConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<UnitMeasurementDisplayModel, UnitMeasurementConfigurationPageModel>, UnitMeasurementConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<KnowledgeAreaDisplayModel, KnowledgeAreaConfigurationPageModel>, KnowledgeAreaConfigurationPageFactory>() ;

            return builder;
        }
    }
}
