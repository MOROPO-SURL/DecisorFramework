namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;

public class NaturalClientSampleAnalysisServiceExecutionDetailPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.NaturalClientSampleAnalysisServiceExecutionDisplayModel>
{
    public Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.NaturalClientSampleAnalysisServiceExecutionDisplayModel> Build(Interop.API.Common.Models.Display.NaturalClientSampleAnalysisServiceExecutionDisplayModel model, System.Action<Interop.API.Common.Models.Display.NaturalClientSampleAnalysisServiceExecutionDisplayModel, int?> delegationAction = null)
    {
        return new Pages.Detail.NaturalClientSampleAnalysisServiceExecutionDetailPage(model, delegationAction);
    }
}