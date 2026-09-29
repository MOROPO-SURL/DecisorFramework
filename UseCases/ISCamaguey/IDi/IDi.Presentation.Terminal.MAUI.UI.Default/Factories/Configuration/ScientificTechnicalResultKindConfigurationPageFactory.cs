namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration;

public class ScientificTechnicalResultKindConfigurationPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.ScientificTechnicalResultKindDisplayModel, Models.Page.Configuration.ScientificTechnicalResultKindConfigurationPageModel>
{
    public async System.Threading.Tasks.Task<Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.ScientificTechnicalResultKindDisplayModel, Interop.API.Common.Models.Display.ScientificTechnicalResultKindDisplayModel, Models.Page.Configuration.ScientificTechnicalResultKindConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.ScientificTechnicalResultKindDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.ScientificTechnicalResultKindDisplayModel model)
    {
        return new Pages.Configuration.ScientificTechnicalResultKindConfigurationPage(configurationSuccessAction, new Models.Page.Configuration.ScientificTechnicalResultKindConfigurationPageModel(model), new Validators.ScientificTechnicalResultKindConfigurationValidator());
    }
}