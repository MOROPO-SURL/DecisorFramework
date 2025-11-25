namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;

public class NaturalClientSampleAnalysisServiceOrderDetailPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.NaturalClientSampleAnalysisServiceOrderDisplayModel>
{
    public Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.NaturalClientSampleAnalysisServiceOrderDisplayModel> Build(Interop.API.Common.Models.Display.NaturalClientSampleAnalysisServiceOrderDisplayModel model, System.Action<Interop.API.Common.Models.Display.NaturalClientSampleAnalysisServiceOrderDisplayModel, int?> delegationAction = null)
    {
        return new Pages.Detail.NaturalClientSampleAnalysisServiceOrderDetailPage(model, delegationAction);
    }
}
