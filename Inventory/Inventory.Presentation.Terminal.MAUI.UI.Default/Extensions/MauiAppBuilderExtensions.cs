using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade;
using MOROPO.Framework.Decisor.Inventory.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Inventory.Presentation.Terminal.MAUI.Models.Page.Configuration;
using MOROPO.Framework.Decisor.Inventory.Presentation.Terminal.MAUI.UI.Default.Factories;
using MOROPO.Framework.Decisor.Inventory.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;
using MOROPO.Framework.Decisor.Inventory.Presentation.Terminal.MAUI.UI.Default.Pages.Detail;

namespace MOROPO.Framework.Decisor.Inventory.Presentation.Terminal.MAUI.UI.Default.Extensions
{
    public static class MauiAppBuilderExtensions
    {
        public static Microsoft.Maui.Hosting.MauiAppBuilder UseDecisorFrameworkInventory(this Microsoft.Maui.Hosting.MauiAppBuilder builder)
        {
            builder.Services
                // DetailPage factory resgistration !!!
                .AddSingleton<IDetailContentPageFactoryFacade<WarehouseDisplayModel, WarehouseDetailPage>, WarehouseDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<ProductDisplayModel, ProductDetailPage>, ProductDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<FamilyDisplayModel, FamilyDetailPage>, FamilyDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<UnitMeasurementDisplayModel, UnitMeasurementDetailPage>, UnitMeasurementDetailPageFactory>()

                // ConfigurationPage factory resgistration !!!
                .AddSingleton<IConfigurationContentPageFactoryFacade<WarehouseDisplayModel, WarehouseConfigurationPageModel, WarehouseConfigurationPage>, WarehouseConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<WarehousingAreaDisplayModel, WarehousingAreaConfigurationPageModel, WarehousingAreaConfigurationPage>, WarehousingAreaConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<ProductDisplayModel, ProductConfigurationPageModel, ProductConfigurationPage>, ProductConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<FamilyDisplayModel, FamilyConfigurationPageModel, FamilyConfigurationPage>, FamilyConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<UnitMeasurementDisplayModel, UnitMeasurementConfigurationPageModel, UnitMeasurementConfigurationPage>, UnitMeasurementConfigurationPageFactory>();

            return builder;
        }
    }
}
