namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class SalaryConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.SalaryStandardDisplayModel, Models.Page.Configuration.SalaryStandardConfigurationPageModel>
    {
        public Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.SalaryStandardDisplayModel, Interop.API.Common.Models.Display.SalaryStandardDisplayModel, Models.Page.Configuration.SalaryStandardConfigurationPageModel> Build(System.Action<Interop.API.Common.Models.Display.SalaryStandardDisplayModel> configurationSuccessAction, Models.Page.Configuration.SalaryStandardConfigurationPageModel model)
        {
            return new Pages.Configuration.SalaryStandardConfigurationPage(configurationSuccessAction, model);
        }
    }
}
