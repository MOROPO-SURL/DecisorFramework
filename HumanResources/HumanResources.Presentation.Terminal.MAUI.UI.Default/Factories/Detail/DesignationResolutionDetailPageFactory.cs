namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;

public class DesignationResolutionDetailPageFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Interop.API.Common.Models.Display.DesignationResolutionDisplayModel>
{
    public Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.DesignationResolutionDisplayModel> Build(Interop.API.Common.Models.Display.DesignationResolutionDisplayModel model, System.Action<Interop.API.Common.Models.Display.DesignationResolutionDisplayModel, int?> delegationAction = null)
    {
        return new Pages.Detail.DesignationResolutionDetailPage(model, delegationAction);
    }
}
