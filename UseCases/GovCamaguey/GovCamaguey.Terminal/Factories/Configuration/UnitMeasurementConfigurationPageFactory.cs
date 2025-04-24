namespace MOROPO.GovCamaguey.Decisor.Prototype.Terminal.Factories.Configuration
{
    public class UnitMeasurementConfigurationPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.UnitMeasurementDisplayModel, Models.Page.Configuration.UnitMeasurementConfigurationPageModel, UI.Pages.Configuration.UnitMeasurementConfigurationPage>
    {
        public UI.Pages.Configuration.UnitMeasurementConfigurationPage Build(System.Action<Interop.API.Common.Models.Display.UnitMeasurementDisplayModel> configurationSuccessAction, Models.Page.Configuration.UnitMeasurementConfigurationPageModel model)
        {
            return new UI.Pages.Configuration.UnitMeasurementConfigurationPage(configurationSuccessAction, model);
        }
    }
}