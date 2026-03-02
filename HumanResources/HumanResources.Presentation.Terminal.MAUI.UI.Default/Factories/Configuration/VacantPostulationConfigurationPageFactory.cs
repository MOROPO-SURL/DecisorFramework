namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class VacantPostulationConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.VacantPostulationDisplayModel, Models.Page.Configuration.VacantPostulationConfigurationPageModel>
    {
        public async System.Threading.Tasks.Task<Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.VacantPostulationDisplayModel, Interop.API.Common.Models.Display.VacantPostulationDisplayModel, Models.Page.Configuration.VacantPostulationConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.VacantPostulationDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.VacantPostulationDisplayModel model)
        {
            return new Pages.Configuration.VacantPostulationConfigurationPage(configurationSuccessAction, new Models.Page.Configuration.VacantPostulationConfigurationPageModel(model), new Validators.VacantPostulationConfigurationValidator());
        }
    }
}
