namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration;

public class AwardKindConfigurationPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.AwardKindDisplayModel, Models.Page.Configuration.AwardKindConfigurationPageModel>
{
    public async System.Threading.Tasks.Task<Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.AwardKindDisplayModel, Interop.API.Common.Models.Display.AwardKindDisplayModel, Models.Page.Configuration.AwardKindConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.AwardKindDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.AwardKindDisplayModel model)
    {
        return new Pages.Configuration.AwardKindConfigurationPage(configurationSuccessAction, new Models.Page.Configuration.AwardKindConfigurationPageModel(model), new Validators.AwardKindConfigurationValidator());
    }
}