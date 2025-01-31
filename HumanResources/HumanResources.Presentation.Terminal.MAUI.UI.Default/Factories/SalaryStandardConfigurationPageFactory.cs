namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Factories
{
    public class SalaryConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.SalaryStandardDisplayModel, Models.Page.Configuration.SalaryStandardConfigurationPageModel, Pages.Configuration.SalaryStandardConfigurationPage>
    {
        public Pages.Configuration.SalaryStandardConfigurationPage Build(System.Action<Interop.API.Common.Models.Display.SalaryStandardDisplayModel> configurationSuccessAction, Models.Page.Configuration.SalaryStandardConfigurationPageModel model)
        {
            return new Pages.Configuration.SalaryStandardConfigurationPage(configurationSuccessAction, model);
        }
    }
}
