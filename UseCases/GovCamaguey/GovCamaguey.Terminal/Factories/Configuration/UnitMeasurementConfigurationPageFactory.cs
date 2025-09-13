namespace MOROPO.GovCamaguey.Decisor.Prototype.Terminal.Factories.Configuration
{
    public class UnitMeasurementConfigurationPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.UnitMeasurementDisplayModel, Models.Page.Configuration.UnitMeasurementConfigurationPageModel>
    {
        public Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.UnitMeasurementDisplayModel, Interop.API.Common.Models.Display.UnitMeasurementDisplayModel, Models.Page.Configuration.UnitMeasurementConfigurationPageModel> Build(System.Action<Interop.API.Common.Models.Display.UnitMeasurementDisplayModel> configurationSuccessAction, Models.Page.Configuration.UnitMeasurementConfigurationPageModel model)
        {
            return new UI.Pages.Configuration.UnitMeasurementConfigurationPage(configurationSuccessAction, model);
        }
    }
}