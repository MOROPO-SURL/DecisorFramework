namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;

public class LegalClientGroundIntegralStudyServiceExecutionDetailPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.LegalClientGroundIntegralStudyServiceExecutionDisplayModel>
{
    public Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.LegalClientGroundIntegralStudyServiceExecutionDisplayModel> Build(Interop.API.Common.Models.Display.LegalClientGroundIntegralStudyServiceExecutionDisplayModel model, System.Action<Interop.API.Common.Models.Display.LegalClientGroundIntegralStudyServiceExecutionDisplayModel, int?> delegationAction = null)
    {
        return new Pages.Detail.LegalClientGroundIntegralStudyServiceExecutionDetailPage(model, delegationAction);
    }
}