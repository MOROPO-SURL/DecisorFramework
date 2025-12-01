namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;

public class WorkingGroupDetailPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.WorkingGroupDisplayModel>
{
    public Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.WorkingGroupDisplayModel> Build(Interop.API.Common.Models.Display.WorkingGroupDisplayModel model, System.Action<Interop.API.Common.Models.Display.WorkingGroupDisplayModel, int?> delegationAction = null)
    {
        return new Pages.Detail.WorkingGroupDetailPage(model, delegationAction);
    }
}