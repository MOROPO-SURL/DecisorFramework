namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class VacantPostulationConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.VacantPostulationDisplayModel, Models.Page.Configuration.VacantPostulationConfigurationPageModel, Pages.Configuration.VacantPostulationConfigurationPage>
    {
        public Pages.Configuration.VacantPostulationConfigurationPage Build(System.Action<Interop.API.Common.Models.Display.VacantPostulationDisplayModel> configurationSuccessAction, Models.Page.Configuration.VacantPostulationConfigurationPageModel model)
        {
            return new Pages.Configuration.VacantPostulationConfigurationPage(configurationSuccessAction, model);
        }
    }
}
