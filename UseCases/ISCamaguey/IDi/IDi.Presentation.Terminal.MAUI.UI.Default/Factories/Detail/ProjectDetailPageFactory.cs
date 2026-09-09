namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;

public class ProjectDetailPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.ProjectDisplayModel>
{
    public Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.ProjectDisplayModel> Build(Interop.API.Common.Models.Display.ProjectDisplayModel model, System.Action<Interop.API.Common.Models.Display.ProjectDisplayModel, int?> delegationAction = null)
    {
        return new Pages.Detail.ProjectDetailPage(model, delegationAction);
    }
}