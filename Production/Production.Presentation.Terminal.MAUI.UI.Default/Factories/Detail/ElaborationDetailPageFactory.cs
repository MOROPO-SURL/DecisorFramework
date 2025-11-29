namespace MOROPO.Framework.Decisor.Production.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;

public class ElaborationDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.ElaborationDisplayModel>
{
    public Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.ElaborationDisplayModel> Build(Interop.API.Common.Models.Display.ElaborationDisplayModel model, System.Action<Interop.API.Common.Models.Display.ElaborationDisplayModel, int?> delegationAction = null)
    {
        return new Pages.Detail.ElaborationDetailPage(model, delegationAction);
    }
}