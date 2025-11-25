namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration;

public class SampleReceptionLabelConfigurationPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IConfigurationContentPageFactoryFacade<Interop.API.Common.Models.Display.SampleReceptionLabelDisplayModel, Models.Page.Configuration.SampleReceptionLabelConfigurationPageModel>
{
    public async System.Threading.Tasks.Task<Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.ConfigurationBaseContentPage<Interop.API.Common.Models.Display.SampleReceptionLabelDisplayModel, Interop.API.Common.Models.Display.SampleReceptionLabelDisplayModel, Models.Page.Configuration.SampleReceptionLabelConfigurationPageModel>> BuildAsync(System.Action<Interop.API.Common.Models.Display.SampleReceptionLabelDisplayModel> configurationSuccessAction, Interop.API.Common.Models.Display.SampleReceptionLabelDisplayModel model)
    {
        return new Pages.Configuration.SampleReceptionLabelConfigurationPage(configurationSuccessAction, new Models.Page.Configuration.SampleReceptionLabelConfigurationPageModel(model), new Validators.SampleReceptionLabelConfigurationValidator());
    }
}