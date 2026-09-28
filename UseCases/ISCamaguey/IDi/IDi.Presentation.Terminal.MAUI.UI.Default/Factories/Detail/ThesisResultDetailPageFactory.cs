namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;

public class ThesisResultDetailPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.ThesisResultDisplayModel>
{
    public Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.ThesisResultDisplayModel> Build(Interop.API.Common.Models.Display.ThesisResultDisplayModel model, System.Action<Interop.API.Common.Models.Display.ThesisResultDisplayModel, int?> delegationAction = null)
    {
        return new Pages.Detail.ThesisResultDetailPage(model, delegationAction);
    }
}