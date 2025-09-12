using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade;
using MOROPO.Framework.Decisor.Inventory.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Inventory.Presentation.Terminal.MAUI.Models.Page.Configuration;
using MOROPO.Framework.Decisor.Inventory.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration;
using MOROPO.Framework.Decisor.Inventory.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;

namespace MOROPO.Framework.Decisor.Inventory.Presentation.Terminal.MAUI.UI.Default.Extensions
{
    public static class MauiAppBuilderExtensions
    {
        public static Microsoft.Maui.Hosting.MauiAppBuilder UseDecisorFrameworkInventory(this Microsoft.Maui.Hosting.MauiAppBuilder builder)
        {
            builder.Services
                // DetailPage factory resgistration !!!
                .AddSingleton<IDetailContentPageFactoryFacade<WarehouseDisplayModel>, WarehouseDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<ProductDisplayModel>, ProductDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<FamilyDisplayModel>, FamilyDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<UnitMeasurementDisplayModel>, UnitMeasurementDetailPageFactory>()

                // ConfigurationPage factory resgistration !!!
                .AddSingleton<IConfigurationContentPageFactoryFacade<WarehouseDisplayModel, WarehouseConfigurationPageModel>, WarehouseConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<WarehousingAreaDisplayModel, WarehousingAreaConfigurationPageModel>, WarehousingAreaConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<ProductDisplayModel, ProductConfigurationPageModel>, ProductConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<FamilyDisplayModel, FamilyConfigurationPageModel>, FamilyConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<UnitMeasurementDisplayModel, UnitMeasurementConfigurationPageModel>, UnitMeasurementConfigurationPageFactory>();

            return builder;
        }
    }
}
