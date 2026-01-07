namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;

public class WorkPositionDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.WorkPositionDisplayModel>
{
    public Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.WorkPositionDisplayModel> Build(Interop.API.Common.Models.Display.WorkPositionDisplayModel model, System.Action<Interop.API.Common.Models.Display.WorkPositionDisplayModel, int?> delegationAction = null)
    {
        return new Pages.Detail.WorkPositionDetailPage(model, delegationAction);
    }
}
