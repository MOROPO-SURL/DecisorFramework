namespace MOROPO.Framework.Decisor.Inventory.Presentation.Terminal.MAUI.UI.Default.Factories
{
    public class FamilyConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.FamilyDisplayModel, Models.Page.Configuration.FamilyConfigurationPageModel, Pages.Configuration.FamilyConfigurationPage>
    {
        public Pages.Configuration.FamilyConfigurationPage Build(System.Action<Interop.API.Common.Models.Display.FamilyDisplayModel> configurationSuccessAction, Models.Page.Configuration.FamilyConfigurationPageModel model)
        {
            return new Pages.Configuration.FamilyConfigurationPage(configurationSuccessAction, model);
        }
    }
}
