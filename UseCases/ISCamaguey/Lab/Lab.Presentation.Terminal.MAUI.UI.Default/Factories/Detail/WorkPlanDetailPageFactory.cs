namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;

public class WorkPlanDetailPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.WorkPlanDisplayModel>
{
    public Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.WorkPlanDisplayModel> Build(Interop.API.Common.Models.Display.WorkPlanDisplayModel model, System.Action<Interop.API.Common.Models.Display.WorkPlanDisplayModel, int?> delegationAction = null)
    {
        return new Pages.Detail.WorkPlanDetailPage(model, delegationAction);
    }
}