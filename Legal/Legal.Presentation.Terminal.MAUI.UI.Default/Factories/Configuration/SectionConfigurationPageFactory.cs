namespace MOROPO.Framework.Decisor.Legal.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class SectionConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.SectionDisplayModel, Models.Page.Configuration.SectionConfigurationPageModel, Pages.Configuration.SectionConfigurationPage>
    {
        public Pages.Configuration.SectionConfigurationPage Build(System.Action<Interop.API.Common.Models.Display.SectionDisplayModel> configurationSuccessAction, Models.Page.Configuration.SectionConfigurationPageModel model)
        {
            return new Pages.Configuration.SectionConfigurationPage(configurationSuccessAction, model);
        }
    }
}
