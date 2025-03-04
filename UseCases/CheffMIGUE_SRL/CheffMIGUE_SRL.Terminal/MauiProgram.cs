using CommunityToolkit.Maui;
using Maui.FreakyControls.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using MOROPO.Framework.Decisor.Commercial.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Commercial.Presentation.Terminal.MAUI.UI.Default.Factories;
using MOROPO.Framework.Decisor.Commercial.Presentation.Terminal.MAUI.UI.Default.Pages.Detail;
using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.Models.Page.Configuration;
using MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Factories;
using MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;
using MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Detail;
using MOROPO.Framework.Decisor.Financial.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Financial.Presentation.Terminal.MAUI.Models.Page.Configuration;
using MOROPO.Framework.Decisor.Financial.Presentation.Terminal.MAUI.UI.Default.Factories;
using MOROPO.Framework.Decisor.Financial.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;
using MOROPO.Framework.Decisor.Financial.Presentation.Terminal.MAUI.UI.Default.Pages.Detail;
using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.Page.Configuration;
using MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Factories;
using MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;
using MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Pages.Detail;
using MOROPO.Framework.Decisor.Inventory.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Inventory.Presentation.Terminal.MAUI.Models.Page.Configuration;
using MOROPO.Framework.Decisor.Inventory.Presentation.Terminal.MAUI.UI.Default.Factories;
using MOROPO.Framework.Decisor.Inventory.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;
using MOROPO.Framework.Decisor.Inventory.Presentation.Terminal.MAUI.UI.Default.Pages.Detail;
using MOROPO.Framework.Decisor.Production.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Production.Presentation.Terminal.MAUI.Models.Page.Configuration;
using MOROPO.Framework.Decisor.Production.Presentation.Terminal.MAUI.UI.Default.Factories;
using MOROPO.Framework.Decisor.Production.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;
using MOROPO.Framework.Decisor.Production.Presentation.Terminal.MAUI.UI.Default.Pages.Detail;
using MOROPO.Framework.Decisor.Purchasing.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.Models.Page.Configuration;
using MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.UI.Default.Factories;
using MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;
using MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.UI.Default.Pages.Detail;
using SkiaSharp.Views.Maui.Controls.Hosting;

namespace MOROPO.CheffMIGUE.Decisor.Terminal
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder
               .UseMauiApp<App>()
               .UseMauiCommunityToolkit()
               .UseMauiCommunityToolkitMediaElement()
               .UseSkiaSharp()
               .ConfigureFonts(fonts =>
               {
                   fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                   fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                   fonts.AddFont("materialdesignicons-webfont.ttf", "MaterialDesignIcons");
               })
               .InitializeFreakyControls()
           .Services
               .AddSingleton<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade, Providers.HttpClientHelperProvider>()
               .AddSingleton<Framework.Decisor.Core.Presentation.Terminal.MAUI.Providers.Facade.IRuntimeContextProviderFacade, Providers.SingleRuntimeContextProvider>()
               .AddSingleton<Framework.Decisor.Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade, Helpers.MainExceptionHandlingHelper>()
               .AddSingleton<Framework.Decisor.Core.Presentation.Terminal.MAUI.Managers.Facade.ISessionManagerFacade, Framework.Decisor.Core.Presentation.Terminal.MAUI.Managers.DefaultSessionManager>()
               // DetailPage factory registrations !!!
               .AddSingleton<IDetailContentPageFactoryFacade<SchoolingDisplayModel, SchoolingDetailPage>, SchoolingDetailPageFactory>()
               .AddSingleton<IDetailContentPageFactoryFacade<SalaryStandardDisplayModel, SalaryStandardDetailPage>, SalaryStandardDetailPageFactory>()
               .AddSingleton<IDetailContentPageFactoryFacade<PersonContactDisplayModel, PersonContactDetailPage>, PersonContactDetailPageFactory>()
               .AddSingleton<IDetailContentPageFactoryFacade<OrganizationContactDisplayModel, OrganizationContactDetailPage>, OrganizationContactDetailPageFactory>()
               .AddSingleton<IDetailContentPageFactoryFacade<NaturalBusinessKindDisplayModel, NaturalBusinessKindDetailPage>, NaturalBusinessKindDetailPageFactory>()
               .AddSingleton<IDetailContentPageFactoryFacade<LegalBusinessKindDisplayModel, LegalBusinessKindDetailPage>, LegalBusinessKindDetailPageFactory>()
               .AddSingleton<IDetailContentPageFactoryFacade<BankAgencyDisplayModel, BankAgencyDetailPage>, BankAgencyDetailPageFactory>()
               .AddSingleton<IDetailContentPageFactoryFacade<WarehouseDisplayModel, WarehouseDetailPage>, WarehouseDetailPageFactory>()
               .AddSingleton<IDetailContentPageFactoryFacade<ProductDisplayModel, ProductDetailPage>, ProductDetailPageFactory>()
               .AddSingleton<IDetailContentPageFactoryFacade<FamilyDisplayModel, FamilyDetailPage>, FamilyDetailPageFactory>()
               .AddSingleton<IDetailContentPageFactoryFacade<UnitMeasurementDisplayModel, UnitMeasurementDetailPage>, UnitMeasurementDetailPageFactory>()
               .AddSingleton<IDetailContentPageFactoryFacade<PaymentTermDisplayModel, PaymentTermDetailPage>, PaymentTermDetailPageFactory>()
               .AddSingleton<IDetailContentPageFactoryFacade<PurchaseZoneDisplayModel, PurchaseZoneDetailPage>, PurchaseZoneDetailPageFactory>()
               .AddSingleton<IDetailContentPageFactoryFacade<WorkPositionDisplayModel, WorkPositionDetailPage>, WorkPositionDetailPageFactory>()
               .AddSingleton<IDetailContentPageFactoryFacade<EmployeeDisplayModel, EmployeeDetailPage>, EmployeeDetailPageFactory>()
               .AddSingleton<IDetailContentPageFactoryFacade<ProductionOrderDisplayModel, ProductionOrderDetailPage>, ProductionOrderDetailPageFactory>()
               // ConfigurationPage factory resgistration !!!
               .AddSingleton<IConfigurationContentPageFactoryFacade<SalaryStandardDisplayModel, SalaryStandardConfigurationPageModel, SalaryStandardConfigurationPage>, SalaryConfigurationPageFactory>()
               .AddSingleton<IConfigurationContentPageFactoryFacade<PersonContactDisplayModel, PersonContactConfigurationPageModel, PersonContactConfigurationPage>, PersonContactConfigurationPageFactory>()
               .AddSingleton<IConfigurationContentPageFactoryFacade<WorkPositionDisplayModel, WorkPositionConfigurationPageModel, WorkPositionConfigurationPage>, WorkPositionConfigurationPageFactory>()
               .AddSingleton<IConfigurationContentPageFactoryFacade<PersonContactDisplayModel, PersonContactConfigurationPageModel, PersonContactConfigurationPage>, PersonContactConfigurationPageFactory>()
               .AddSingleton<IConfigurationContentPageFactoryFacade<OrganizationContactDisplayModel, OrganizationContactConfigurationPageModel, OrganizationContactConfigurationPage>, OrganizationContactConfigurationPageFactory>()
               .AddSingleton<IConfigurationContentPageFactoryFacade<BankAgencyDisplayModel, BankAgencyConfigurationPageModel, BankAgencyConfigurationPage>, BankAgencyConfigurationPageFactory>()
               .AddSingleton<IConfigurationContentPageFactoryFacade<WarehouseDisplayModel, WarehouseConfigurationPageModel, WarehouseConfigurationPage>, WarehouseConfigurationPageFactory>()
               .AddSingleton<IConfigurationContentPageFactoryFacade<WarehousingAreaDisplayModel, WarehousingAreaConfigurationPageModel, WarehousingAreaConfigurationPage>, WarehousingAreaConfigurationPageFactory>()
               .AddSingleton<IConfigurationContentPageFactoryFacade<ProductDisplayModel, ProductConfigurationPageModel, ProductConfigurationPage>, ProductConfigurationPageFactory>()
               .AddSingleton<IConfigurationContentPageFactoryFacade<FamilyDisplayModel, FamilyConfigurationPageModel, FamilyConfigurationPage>, FamilyConfigurationPageFactory>()
               .AddSingleton<IConfigurationContentPageFactoryFacade<UnitMeasurementDisplayModel, UnitMeasurementConfigurationPageModel, UnitMeasurementConfigurationPage>, UnitMeasurementConfigurationPageFactory>()
               .AddSingleton<IConfigurationContentPageFactoryFacade<PurchaseZoneDisplayModel, PurchaseZoneConfigurationPageModel, PurchaseZoneConfigurationPage>, PurchaseZoneConfigurationPageFactory>()
               .AddSingleton<IConfigurationContentPageFactoryFacade<WorkPositionDisplayModel, WorkPositionConfigurationPageModel, WorkPositionConfigurationPage>, WorkPositionConfigurationPageFactory>()
               .AddSingleton<IConfigurationContentPageFactoryFacade<ProductionOrderDisplayModel, ProductionOrderConfigurationPageModel, ProductionOrderConfigurationPage>, ProductionOrderConfigurationPageFactory>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
