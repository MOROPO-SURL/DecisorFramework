namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;

public class WorkforceDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.WorkforceDisplayModel>
{
    public Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.WorkforceDisplayModel> Build(Interop.API.Common.Models.Display.WorkforceDisplayModel model, System.Action<Interop.API.Common.Models.Display.WorkforceDisplayModel, int?> delegationAction = null)
    {
        return new Pages.Detail.WorkforceDetailPage(model, delegationAction);
    }
}