namespace MOROPO.Framework.Decisor.Inventory.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class UnitMeasurementConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.UnitMeasurementDisplayModel, Models.Page.Configuration.UnitMeasurementConfigurationPageModel, Pages.Configuration.UnitMeasurementConfigurationPage>
    {
        public Pages.Configuration.UnitMeasurementConfigurationPage Build(System.Action<Interop.API.Common.Models.Display.UnitMeasurementDisplayModel> configurationSuccessAction, Models.Page.Configuration.UnitMeasurementConfigurationPageModel model)
        {
            return new Pages.Configuration.UnitMeasurementConfigurationPage(configurationSuccessAction, model);
        }
    }
}
