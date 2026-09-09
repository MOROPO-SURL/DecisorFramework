namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;

public class ProjectCategoryDetailPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.ProjectCategoryDisplayModel>
{
    public Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.ProjectCategoryDisplayModel> Build(Interop.API.Common.Models.Display.ProjectCategoryDisplayModel model, System.Action<Interop.API.Common.Models.Display.ProjectCategoryDisplayModel, int?> delegationAction = null)
    {
        return new Pages.Detail.ProjectCategoryDetailPage(model);
    }
}
