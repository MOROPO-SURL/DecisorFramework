namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;

public class NaturalClientGroundIntegralStudyServiceExecutionDetailPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.NaturalClientGroundIntegralStudyServiceExecutionDisplayModel>
{
    public Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.NaturalClientGroundIntegralStudyServiceExecutionDisplayModel> Build(Interop.API.Common.Models.Display.NaturalClientGroundIntegralStudyServiceExecutionDisplayModel model, System.Action<Interop.API.Common.Models.Display.NaturalClientGroundIntegralStudyServiceExecutionDisplayModel, int?> delegationAction = null)
    {
        return new Pages.Detail.NaturalClientGroundIntegralStudyServiceExecutionDetailPage(model, delegationAction);
    }
}