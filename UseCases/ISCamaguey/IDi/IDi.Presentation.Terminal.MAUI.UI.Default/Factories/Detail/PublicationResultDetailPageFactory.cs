namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;

public class PublicationResultDetailPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.PublicationResultDisplayModel>
{
    public Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.PublicationResultDisplayModel> Build(Interop.API.Common.Models.Display.PublicationResultDisplayModel model, System.Action<Interop.API.Common.Models.Display.PublicationResultDisplayModel, int?> delegationAction = null)
    {
        return new Pages.Detail.PublicationResultDetailPage(model, delegationAction);
    }
}