
namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration
{
    public class KnowledgeAreaConfigurationPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.KnowledgeAreaDisplayModel, Models.Page.Configuration.KnowledgeAreaConfigurationPageModel>
    {
        public async System.Threading.Tasks.Task<Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.KnowledgeAreaDisplayModel, Interop.API.Common.Models.Display.KnowledgeAreaDisplayModel, Models.Page.Configuration.KnowledgeAreaConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.KnowledgeAreaDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.KnowledgeAreaDisplayModel model)
        {
            return new Pages.Configuration.KnowledgeAreaConfigurationPage(configurationSuccessAction, new Models.Page.Configuration.KnowledgeAreaConfigurationPageModel(model), new Validators.KnowledgeAreaConfigurationValidator());
        }
    }
}
