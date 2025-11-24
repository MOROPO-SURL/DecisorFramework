namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;

public class LegalClientSampleAnalysisServiceOrderDetailPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.LegalClientSampleAnalysisServiceOrderDisplayModel>
{
    public Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.LegalClientSampleAnalysisServiceOrderDisplayModel> Build(Interop.API.Common.Models.Display.LegalClientSampleAnalysisServiceOrderDisplayModel model, System.Action<Interop.API.Common.Models.Display.LegalClientSampleAnalysisServiceOrderDisplayModel, int?> delegationAction = null)
    {
        return new Pages.Detail.LegalClientSampleAnalysisServiceOrderDetailPage(model, delegationAction);
    }
}