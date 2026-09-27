namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;

public class NaturalClientTrainingServiceExecutionDetailPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.NaturalClientTrainingServiceExecutionDisplayModel>
{
    public Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.NaturalClientTrainingServiceExecutionDisplayModel> Build(Interop.API.Common.Models.Display.NaturalClientTrainingServiceExecutionDisplayModel model, System.Action<Interop.API.Common.Models.Display.NaturalClientTrainingServiceExecutionDisplayModel, int?> delegationAction = null)
    {
        return new Pages.Detail.NaturalClientTrainingServiceExecutionDetailPage(model, delegationAction);
    }
}