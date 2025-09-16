namespace MOROPO.Framework.Decisor.Governance.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class MeetingConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.MeetingDisplayModel, Models.Page.Configuration.MeetingConfigurationPageModel>
    {
        public Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.MeetingDisplayModel, Interop.API.Common.Models.Display.MeetingDisplayModel, Models.Page.Configuration.MeetingConfigurationPageModel> Build(System.Action<Interop.API.Common.Models.Display.MeetingDisplayModel> configurationSuccessAction, Models.Page.Configuration.MeetingConfigurationPageModel model)
        {
            return new Pages.Configuration.MeetingConfigurationPage(configurationSuccessAction, model);
        }
    }
}
