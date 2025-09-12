namespace MOROPO.Framework.Decisor.Legal.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class SectionConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.SectionDisplayModel, Models.Page.Configuration.SectionConfigurationPageModel>
    {
        public Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.SectionDisplayModel, Interop.API.Common.Models.Display.SectionDisplayModel, Models.Page.Configuration.SectionConfigurationPageModel> Build(System.Action<Interop.API.Common.Models.Display.SectionDisplayModel> configurationSuccessAction, Models.Page.Configuration.SectionConfigurationPageModel model)
        {
            return new Pages.Configuration.SectionConfigurationPage(configurationSuccessAction, model);
        }
    }
}
