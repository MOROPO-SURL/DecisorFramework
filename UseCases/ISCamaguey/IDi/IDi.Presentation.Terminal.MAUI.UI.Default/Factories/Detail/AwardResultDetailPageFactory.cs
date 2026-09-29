namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;

public class AwardResultDetailPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.AwardResultDisplayModel>
{
    public Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.AwardResultDisplayModel> Build(Interop.API.Common.Models.Display.AwardResultDisplayModel model, System.Action<Interop.API.Common.Models.Display.AwardResultDisplayModel, int?> delegationAction = null)
    {
        return new Pages.Detail.AwardResultDetailPage(model, delegationAction);
    }
}