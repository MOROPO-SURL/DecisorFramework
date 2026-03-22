namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;

public class ResearcherCategoryDetailPageFactory : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.ResearcherCategoryDisplayModel>
{
    public Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.ResearcherCategoryDisplayModel> Build(Interop.API.Common.Models.Display.ResearcherCategoryDisplayModel model, System.Action<Interop.API.Common.Models.Display.ResearcherCategoryDisplayModel, int?> delegationAction = null)
    {
        return new Pages.Detail.ResearcherCategoryDetailPage(model);
    }
}
