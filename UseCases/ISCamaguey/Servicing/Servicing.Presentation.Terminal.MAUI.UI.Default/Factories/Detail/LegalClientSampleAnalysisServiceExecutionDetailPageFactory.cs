namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;

public class LegalClientSampleAnalysisServiceExecutionDetailPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.LegalClientSampleAnalysisServiceExecutionDisplayModel>
{
    public Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.LegalClientSampleAnalysisServiceExecutionDisplayModel> Build(Interop.API.Common.Models.Display.LegalClientSampleAnalysisServiceExecutionDisplayModel model, System.Action<Interop.API.Common.Models.Display.LegalClientSampleAnalysisServiceExecutionDisplayModel, int?> delegationAction = null)
    {
        return new Pages.Detail.LegalClientSampleAnalysisServiceExecutionDetailPage(model, delegationAction);
    }
}