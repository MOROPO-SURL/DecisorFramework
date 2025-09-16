namespace MOROPO.Framework.Decisor.Inventory.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class FamilyConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.FamilyDisplayModel, Models.Page.Configuration.FamilyConfigurationPageModel>
    {
        public Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.FamilyDisplayModel, Interop.API.Common.Models.Display.FamilyDisplayModel, Models.Page.Configuration.FamilyConfigurationPageModel> Build(System.Action<Interop.API.Common.Models.Display.FamilyDisplayModel> configurationSuccessAction, Models.Page.Configuration.FamilyConfigurationPageModel model)
        {
            return new Pages.Configuration.FamilyConfigurationPage(configurationSuccessAction, model);
        }
    }
}
