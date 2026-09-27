namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;

public class LegalClientTrainingServiceExecutionDetailPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.LegalClientTrainingServiceExecutionDisplayModel>
{
    public Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.LegalClientTrainingServiceExecutionDisplayModel> Build(Interop.API.Common.Models.Display.LegalClientTrainingServiceExecutionDisplayModel model, System.Action<Interop.API.Common.Models.Display.LegalClientTrainingServiceExecutionDisplayModel, int?> delegationAction = null)
    {
        return new Pages.Detail.LegalClientTrainingServiceExecutionDetailPage(model, delegationAction);
    }
}